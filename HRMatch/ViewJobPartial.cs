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
    public partial class ViewJobPartial : Form
    {

        bool isEmployer = true;
        string username = "";
        string firstname = "";
        string lastname = "";
        string companyname = "";
        public static int userID = 0;
        public static string globalJobTitle = "";
        public static string globalJobDesc = "";
        public static string globalSkillSet = "";
        int globalItemID = 0;
        private List<EmployerJob> listings;
        private EmployerJob singleJob;
        private EmployerJob singleJobItemPlaceHolder;
        
        EmployerApi employerApi = new EmployerApi();

        public ViewJobPartial()
        {
            InitializeComponent();
            backgroundWorkerListView.WorkerSupportsCancellation = true;

            try
            {
                userID = Convert.ToInt32(LoginPage.globalUserID);
                firstname = LoginPage.globalFirstName.ToString();
                lastname = LoginPage.globalLastName.ToString();
                companyname = LoginPage.globalCompanyName.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(!backgroundWorker1.IsBusy) backgroundWorker1.RunWorkerAsync();
            else
            {
                backgroundWorker1.CancelAsync();
                backgroundWorker1.RunWorkerAsync();
            }
            
        }

        //private void RefreshListBox()
        //{
        //    var connectionStrings = ConfigurationManager.ConnectionStrings["Test"].ToString();

        //    using (SqlConnection conn = new SqlConnection(connectionStrings))
        //    {
        //        var retrieveQuery = "select * from Employer_Jobs where subid=" + userID;
        //        conn.Open();
        //        using (SqlCommand command = new SqlCommand(retrieveQuery, conn))
        //        {
        //            SqlDataReader dr = command.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                while (dr.Read())
        //                {
        //                    EmployerJob employerJob = new EmployerJob
        //                    {
        //                        ID = Convert.ToInt32(dr["ID"]),
        //                        SubID = Convert.ToInt32(dr["SubID"]),
        //                        JobTitle = dr["JobTitle"].ToString(),
        //                        Description = dr["Description"].ToString(),
        //                        SkillSet = dr["SkillSet"].ToString()
        //                    };

        //                    listings.Add(employerJob);
        //                }

        //            }
        //            else
        //            {
        //                MessageBox.Show("No jobs at the moment");
        //            }
        //        }
        //    }
        //}

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //foreach (ListViewItem item in listView1.SelectedItems) singleJobItemPlaceHolder = (EmployerJob)item.Tag;
           

            if (listView1.SelectedItems.Count > 0) singleJobItemPlaceHolder = (EmployerJob)listView1.SelectedItems[0].Tag;
            else return;

            if (!backgroundWorkerListView.IsBusy) backgroundWorkerListView.RunWorkerAsync();
            else backgroundWorkerListView.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //listView1.Items.Clear();

                if (listView1.InvokeRequired)
                {
                    listView1.Invoke((MethodInvoker)delegate ()
                    {
                        listView1.Items.Clear();
                    });
                }

                listings = new List<EmployerJob>();
                EmployerApi.StartAsync("GETALL_PER_USER", userID);
                List<object> freshList = new List<object>();
                freshList = EmployerApi.GetList();
                listings = freshList.Cast<EmployerJob>().ToList();

                //RefreshListBox();

                foreach (var listing in listings)
                {
                    if (listView1.InvokeRequired)
                    {
                        listView1.Invoke((MethodInvoker)delegate ()
                       {
                           ListViewItem item = new ListViewItem();
                           item.Text = listing.JobTitle;
                           item.Tag = listing;
                           listView1.Items.Add(item);
                       });
                    }

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Err: Could not connect to server");
            }
        }

        private void backgroundWorkerListView_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PageHelper.id = singleJobItemPlaceHolder.ID;
                PageHelper.subId = singleJobItemPlaceHolder.SubID;
                EmployerApi.StartAsync("GET", singleJobItemPlaceHolder.ID);
                object tempJob = new object();
                tempJob = EmployerApi.GetSingle();
                singleJob = (EmployerJob)tempJob;

                PageHelper.globalTitle = singleJob.JobTitle;
                PageHelper.globalDescription = singleJob.Description;
                PageHelper.globalSkills = singleJob.SkillSet;
                PageHelper.pageReferrer = this.Name;
                ViewDetailsPartial viewDetails = new ViewDetailsPartial();
                viewDetails.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Err: Could not connect to server");
            }

        }

        private void btnAddJob_Click(object sender, EventArgs e)
        {
            CreateJobPage jobPage = new CreateJobPage();
            jobPage.Text = "Job Details";
            jobPage.ShowDialog();
        }

        //private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        //{
        //    if (backgroundWorkerListView.IsBusy) backgroundWorkerListView.CancelAsync();
        //}
    }
}
