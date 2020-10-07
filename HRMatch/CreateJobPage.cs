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
    public partial class CreateJobPage : Form
    {
        Employer fillerEmployerObject = new Employer { Email = "", FirstName = "", LastName = "", CompanyName = "", Password = "" };
        JobSeeker fillerJobSeekerObject = new JobSeeker { Email = "", FirstName = "", LastName = "", Password = "" };
        private int globalSubID = MainPage.userID;
        bool isEmployer = LoginPage.isEmployer;
        EmployerApi employerApi = new EmployerApi();
        public static EmployerJob globalEmployerJob =  new EmployerJob();

        public CreateJobPage()
        {
            InitializeComponent();
            if (PageHelper.isEmployer)
            {
                lblTitle.Text = "Add Job";
            }
            else
            {
                labelJobTitle.Visible = false;
                tbJobTitle.Visible = false;
            }
            string[] SkillSet = ConfigurationManager.AppSettings["SkillGenre"].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach(var skill in SkillSet)
            {
                comboSkillSet.Items.Add(skill);
            }

        }

        private void comboSkillSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSkillGenre = comboSkillSet.SelectedItem.ToString();

            switch (selectedSkillGenre)
            {
                case "Developer":
                    PopulateSkillSetBox(selectedSkillGenre);
                    break;
            }
        }

        private void PopulateSkillSetBox(string skillGenre)
        {
            string[] skills = ConfigurationManager.AppSettings[skillGenre].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(var skill in skills)
            {
                checkedBoxSkills.Items.Add(skill);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Add a validation that all fields are filled. If not do not execute. 
            //Temporarily executing letting the execution run
            if (checkedBoxSkills.CheckedItems.Count > 0)
            {
                var allSkills = "";
                string[] checkedSkills = checkedBoxSkills.CheckedItems.OfType<string>().ToArray();
                foreach(var checkedSkill in checkedSkills)
                {
                    allSkills += checkedSkill + "|";
                }
                AddJob(allSkills);
            }
            else
                MessageBox.Show("Please select atleast 1 of the skills listed");

        }
        string allSkills;
        private void AddJob(string _allSkills)
        {
            allSkills = _allSkills;
            addJobWorker1.RunWorkerAsync();
        }

        private void UpdateJob()
        {

        }
        int subID = 0;
        string jobTitle = "";
        string description = "";
        string skillSet = "";
        private void addJobWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            

            try
            {
                subID = globalSubID;
                jobTitle = tbJobTitle.Text.ToString().Trim();
                description = tbDescription.Text.ToString().Trim();
                skillSet = allSkills;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please populate remaining fields");
            }


            var empJob = new EmployerJob
            {
                SubID = globalSubID,
                JobTitle = jobTitle,
                Description = description,
                SkillSet = skillSet
            };

            globalEmployerJob = empJob;

            try
            {
                EmployerApi.StartAsync("POST_JOB");
                if (employerApi.GetPostStatus()) MessageBox.Show("Job posted!");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
