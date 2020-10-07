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
    public partial class MainPage: Form
    {
        bool isEmployer = true;
        string username = "";
        string firstname = "";
        string lastname = "";
        string companyname = "";
        public static int userID = 0;
        int globalItemID = 0;
        private List<EmployerJob> listings;
        private JobSeeker_Details jobSeeker_Details;
        private EmployerJob employerJob;


        public MainPage()
        {
            InitializeComponent();
            ButtonFieldPopulate();
            try
            {
                userID = Convert.ToInt32(LoginPage.globalUserID);
                lblFullName.Text = LoginPage.globalUsername.ToString();
                firstname = LoginPage.globalFirstName.ToString();
                lastname = LoginPage.globalLastName.ToString();
                companyname = LoginPage.globalCompanyName.ToString();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ButtonFieldPopulate()
        {
            var createButton = new Button();
            var viewButton = new Button();
            var viewJobs = new Button();

            /**CREATE should only be available for JobSeeker
            * Should grey out if there is already an exisiting profile.
            * Should be able to add a profile.
            ***/

            lblStatus.Text = PageHelper.isEmployer ? "Status: Employer" : "Status: Seeker";
            lblCand.Text = PageHelper.isEmployer ? "Candidates" : "Jobs";

            if (!PageHelper.isEmployer)
            {
                if (!PageHelper.resumePresent)
                {
                    createButton.Text = "Create Profile/Resume";
                    createButton.Width = 145;
                    createButton.AccessibleName = "create";
                    ButtonPanel.Controls.Add(createButton);
                    createButton.Click += new EventHandler(generalButton_Click);
                }

                viewButton.Text = "View Profile";
                viewButton.Width = 145;
                viewButton.Location = new Point(0, 35);
                viewButton.AccessibleName = "view";
                ButtonPanel.Controls.Add(viewButton);
                viewButton.Click += new EventHandler(generalButton_Click);
            }
            else
            {
                viewJobs.Text = "View Jobs";
                viewJobs.Width = 145;
                viewJobs.Location = new Point(0, 70);
                viewJobs.AccessibleName = "viewJob";
                ButtonPanel.Controls.Add(viewJobs);
                viewJobs.Click += new EventHandler(generalButton_Click);
            }

            if (!PageHelper.resumePresent) viewButton.Enabled = false;
            else viewButton.Enabled = true;
            
        }

        private void generalButton_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            string btnAccessName = btn.AccessibleName;

            switch (btnAccessName)
            {
                case "create":
                    CreateButton();                    
                    break;

                case "view":
                    ViewButton();
                    //open new form
                    break;

                case "viewJob":
                    ViewJobButton();
                    break;

                default:
                    break;
            }

        }


        private void CreateButton()
        {
            CreateJobPage jobPage = new CreateJobPage();
            jobPage.Text = "Your Resume";
            jobPage.ShowDialog();

        }

        private void ViewButton()
        {
            if (PageHelper.isEmployer)
            {
                MessageBox.Show("Employer: View job profile");
            }
            else
            {
                PageHelper.pageReferrer = this.Name+"Seeker";
                ViewDetailsPartial detailsPartial = new ViewDetailsPartial();
                detailsPartial.ShowDialog();
            }
        }

        private void ViewJobButton()
        {
            ViewJobPartial viewJobPartial = new ViewJobPartial();
            viewJobPartial.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (PageHelper.isEmployer)
            {
                if (!getAllSeekersWorker1.IsBusy) getAllSeekersWorker1.RunWorkerAsync();
                else
                {
                    getAllSeekersWorker1.CancelAsync();
                    getAllSeekersWorker1.RunWorkerAsync();
                }
            }
            else
            {
                if (!getAllJobPostingWorker1.IsBusy) getAllJobPostingWorker1.RunWorkerAsync();
                else
                {
                    getAllJobPostingWorker1.CancelAsync();
                    getAllJobPostingWorker1.RunWorkerAsync();
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (PageHelper.isEmployer)
                {
                    jobSeeker_Details = (JobSeeker_Details)listView1.SelectedItems[0].Tag;

                }
                else
                {
                    employerJob = (EmployerJob)listView1.SelectedItems[0].Tag;
                }
                listView1.SelectedItems.Clear();
            } 
            else return;

            if (!getIndexWorker1.IsBusy) getIndexWorker1.RunWorkerAsync();
            else getIndexWorker1.CancelAsync();
        }

        private void getAllSeekersWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (listView1.InvokeRequired)
                {
                    listView1.Invoke((MethodInvoker)delegate ()
                    {
                        listView1.Items.Clear();
                        listView1.Columns.Clear();
                    });
                }

                EmployerApi.StartAsync("GETALL_JobSeekers");
                List<JobSeeker_Details> jobSeeker_Details = new List<JobSeeker_Details>();
                jobSeeker_Details = EmployerApi.GetAllJobSeekerList().Cast<JobSeeker_Details>().ToList();
                var counter = 0;
                foreach(var listing in jobSeeker_Details)
                {
                    if (listView1.InvokeRequired)
                    {
                        listView1.Invoke((MethodInvoker)delegate ()
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = listing.LastName + ", " + listing.FirstName;
                            item.Tag = listing;
                            listView1.View = View.Tile;
                            listView1.Columns.Add("",100);
                            listView1.HeaderStyle = ColumnHeaderStyle.None;
                            listView1.FullRowSelect = true;
                            listView1.Items.Add(item);
                            listView1.Items[counter].SubItems.Add(listing.SkillSet);
                            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                            counter++;
                        });
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Err: " + ex);
            }
            
        }

        private void getAllJobPostingWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (listView1.InvokeRequired)
                {
                    listView1.Invoke((MethodInvoker)delegate ()
                    {
                        listView1.Items.Clear();
                        listView1.Columns.Clear();
                    });
                }

                listings = new List<EmployerJob>();
                EmployerApi.StartAsync("GETALL");
                List<object> freshList = new List<object>();
                freshList = EmployerApi.GetList();
                listings = freshList.Cast<EmployerJob>().ToList();

                //RefreshListBox();
                var counter = 0;
                foreach (var listing in listings)
                {
                    if (listView1.InvokeRequired)
                    {
                        listView1.Invoke((MethodInvoker)delegate ()
                        {
                            ListViewItem item = new ListViewItem();
                            //item.Text = listing.JobTitle;
                            //item.Tag = listing;
                            //listView1.Items.Add(item);
                            item.Text = listing.JobTitle;
                            item.Tag = listing;
                            listView1.View = View.Tile;
                            listView1.Columns.Add("", 100);
                            listView1.HeaderStyle = ColumnHeaderStyle.None;
                            listView1.FullRowSelect = true;
                            listView1.Items.Add(item);
                            listView1.Items[counter].SubItems.Add(listing.SkillSet);
                            //listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                            counter++;
                        });
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Err: " + ex);
            }
        }

        private void getIndexWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                
                if (PageHelper.isEmployer)
                {

                    JobSeeker_Details jobSeeker = null;
                    PageHelper.id = jobSeeker_Details.id;
                    EmployerApi.StartAsync("GET_JobSeeker_Profile_w_Resume", PageHelper.id);


                    jobSeeker = (JobSeeker_Details)EmployerApi.GetSingleSeeker();
                    PageHelper.globalTitle = jobSeeker.FirstName + ", " + jobSeeker.LastName;
                    PageHelper.globalDescription = jobSeeker.Description;
                    PageHelper.globalSkills = jobSeeker.SkillSet;
                    
                }
                else
                {
                    EmployerJob empJob = null;
                    PageHelper.id = employerJob.ID;
                    EmployerApi.StartAsync("GET", PageHelper.id); //todo change to EmployerJob


                    empJob = (EmployerJob)EmployerApi.GetSingle();
                    PageHelper.globalTitle = empJob.JobTitle;
                    PageHelper.globalDescription = empJob.Description;
                    PageHelper.globalSkills = empJob.SkillSet;
                }

                PageHelper.pageReferrer = this.Name;
                ViewDetailsPartial viewDetails = new ViewDetailsPartial();
                viewDetails.Text = (PageHelper.isEmployer) ? "Candidate" : "Job Details";
                viewDetails.ShowDialog();
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Err: Could not connect to server" + "==> " + ex);
            }
            
        }

        
    }            
}
