using HRMatch.Api;
using HRMatch.Core;
using HRMatch.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMatch
{
    public partial class ViewDetailsPartial : Form
    {

        bool isEmployer = true;
        string username = "";
        string firstname = "";
        string lastname = "";
        string companyname = "";
        string jobTitle = "";
        string jobDescription = "";
        string skillSet = "";
        public static int userID = 0;
        int globalItemID = 0;
        private List<EmployerJob> listings;

        //I think this is an inefficient approach but this is just for testing
        public static EmployerJob globalEmployerJob = new EmployerJob();
        public static JobSeeker_Resume globalResume = new JobSeeker_Resume();


        EmployerApi employerApi = new EmployerApi();

        public ViewDetailsPartial()
        {
            InitializeComponent();
            try
            {
                //should replace all these to pagehelper so it can be accessed by all?
                jobTitle = ViewJobPartial.globalJobTitle;
                jobDescription = ViewJobPartial.globalJobDesc;
                skillSet = ViewJobPartial.globalSkillSet;

                //FOR "MAINPAGESEEKER" WOULD BE BEST TO PERFORM A BACKGROUND ASYNC REFRESH SO THE PROFILE WOULD AUTOMATICALLY UPDATE??
                //OR MAYBE JUST RESET IT TEMPORARILY THE PAGEHELPER.RESUME* 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            PopulateFields();
        }

        private void PopulateFields()
        {
            //properly populate fields with respect to people class
            try
            {
                cbSkills.Items.Clear();
                if (PageHelper.pageReferrer == "MainPage") // Owner - for dialogs, Parent - for non-dialogs
                {
                    if (PageHelper.isEmployer)
                    {
                        SuperInvokeHide(btnUpdate);
                        SuperInvokeHide(btnDelete);
                        lblSkillsTitle.Text = "Skills";
                    }
                    else
                    {
                        //apply
                        //pin/save
                        btnUpdate.Text = "Apply"; //Resume will be sent
                        btnDelete.Text = "Pin";
                        lblSkillsTitle.Text = "Required Skills";
                        btnUpdate.Enabled = false;
                    }
                    tbTitle.Text = PageHelper.globalTitle;
                    tbJobDescription.Text = PageHelper.globalDescription;

                    var sList = PageHelper.globalSkills.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var s in sList)
                    {
                        cbSkills.Items.Add(s);
                    }
                }
                else if (PageHelper.pageReferrer == "ViewJobPartial")
                {
                    //Do nothing for now
                    tbTitle.Text = PageHelper.globalTitle;
                    tbJobDescription.Text = PageHelper.globalDescription;

                    var sList = PageHelper.globalSkills.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var s in sList)
                    {
                        cbSkills.Items.Add(s);
                    }
                }
                else if (PageHelper.pageReferrer == "MainPageSeeker")
                {
                    tbTitle.Text = PageHelper.resumeTitle;
                    tbJobDescription.Text = PageHelper.resumeDescription;

                    var sList = PageHelper.resumeSkills.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var s in sList)
                    {
                        cbSkills.Items.Add(s);
                    }
                }
                else
                {
                    tbTitle.Text = PageHelper.globalTitle;
                    tbJobDescription.Text = PageHelper.globalDescription;

                    var sList = PageHelper.globalSkills.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var s in sList)
                    {
                        cbSkills.Items.Add(s);
                    }
                }

                
            }
            catch (Exception ex)
            {
                //do nothing - when initializing this object in MainPage - it tries to load the this page which could result
                //into having null values at first
            }
            
            
                
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Update changes?","Job Update", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                if (PageHelper.isEmployer)
                {
                    globalEmployerJob = new EmployerJob {
                        ID = PageHelper.id,
                        SubID = PageHelper.subId,
                        Description = tbJobDescription.Text == null ? "" : tbJobDescription.Text,
                        JobTitle = tbTitle.Text == null ? "" : tbTitle.Text,
                        SkillSet = PageHelper.globalSkills //before updating this make sure to make skills design updatable
                    };

                    updateJobWorker1.RunWorkerAsync();
                }
                else
                {
                    globalResume = new JobSeeker_Resume
                    {
                        ID = PageHelper.resumeId,
                        SubID = PageHelper.resumeSubId,
                        Description = tbJobDescription.Text == null ? "" : tbJobDescription.Text,
                        SkillSet = PageHelper.resumeSkills //before updating this make sure to make skills design updatable
                    };

                    updateJobWorker1.RunWorkerAsync();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (PageHelper.isEmployer)
            {
                deleteWorker1.RunWorkerAsync();
            }
            else
            {
                //Pin it
            }
            
        }

        private void deleteWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (PageHelper.isEmployer)
                {
                    EmployerApi.StartAsync("DELETE_JOB", PageHelper.id);
                    if (EmployerApi.isSuccess)
                    {
                        SuperInvokeText(tbTitle, "Job deleted");
                        SuperInvokeDisabler(btnUpdate, false);
                        SuperInvokeDisabler(btnDelete, false);
                        MessageBox.Show("Job deleted. Please close window and refresh");

                    }
                    else MessageBox.Show("Job has already been deleted.");

                }
                else
                {
                    //EmployerApi.StartAsync("DELETE_RESUME", PageHelper.id);
                } 

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void updateJobWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (PageHelper.isEmployer) EmployerApi.StartAsync("PUT_JOB");
            else EmployerApi.StartAsync("PUT_RES");

            if (EmployerApi.isSuccess)
            {
                PageHelper.resumeDescription = globalResume.Description;
                PageHelper.resumeSkills = globalResume.SkillSet;
                MessageBox.Show("Job updated!");
            }
            else MessageBox.Show("Update failed");

        }

        private void SuperInvokeText(Control control, string verbiage = "")
        {
            if (control.InvokeRequired)
            {
                control.Invoke((MethodInvoker)delegate ()
                {
                    control.Text = verbiage;
                });
            }
        }

        private void SuperInvokeDisabler(Control control, bool superBool = false)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((MethodInvoker)delegate ()
                {
                    control.Enabled = superBool;
                });
            }else control.Enabled = superBool;
        }

        private void SuperInvokeHide(Control control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke((MethodInvoker)delegate ()
                {
                    control.Hide();
                });
            } else control.Hide();
        }

        
    }
}
