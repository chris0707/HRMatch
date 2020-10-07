using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using HRMatch.Core;
using HRMatch.Api;

namespace HRMatch
{
    public partial class LoginPage : Form
    {
        public static string globalUsername = "";
        public static string globalPassword = "";
        public static string globalFirstName = "";
        public static string globalLastName = "";
        public static string globalCompanyName = "";
        public static int globalUserID = 0;
        public static bool isEmployer = false;

        public LoginPage()
        {
            InitializeComponent();
        }


        private void logintBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = tbUsername.Text.ToString();
                string password = tbPassword.Text.ToString();

                if (rbEmployer.Checked)
                {
                    //MessageBox.Show("Employer");
                    PageHelper.isEmployer = true;
                    LoginUser("Employer", username, password);
                }
                else if (rbJobSeeker.Checked)
                {
                    PageHelper.isEmployer = false;
                    LoginUser("JobSeeker", username, password);
                    //MessageBox.Show("JobSeeker");
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: \n" + ex);
            }
            
        }


        private void LoginUser(string role, string username, string password)
        {
            string connectionStrings = ConfigurationManager.ConnectionStrings["Test"].ToString();
            //string validateQuery = "select top 1 ID from " + role + "_Profile where Email='" + username + "' and Password='" + password +"'";
            string validateQuery = "select top 1 * from " + role + "_Profile where Email='" + username + "' and Password='" + password + "'";


            using (SqlConnection connection = new SqlConnection(connectionStrings))
            {
                using(SqlCommand cmd = new SqlCommand(validateQuery, connection))
                {
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                        MessageBox.Show("Account does not exist.");
                    else
                    {
                        while (dr.Read())
                        {
                            ReadSingleRow(dr, role);
                        }
                        dr.Close();
                        globalUsername = username;
                        getResumeWorker1.RunWorkerAsync();
                        MessageBox.Show("Login Success!");
                        //this.Hide();
                        MainPage mainPage = new MainPage();
                        //mainPage.FormClosed += (s, args) => this.Close();
                        mainPage.ShowDialog(); //ShowDialog does not allow to go back to parent or click parent. //Show allows you to go back. 
                        //this.Close();
                    }
                        
                }
            }

        }

        private void ResumePresent()
        {
            

        }

        private void registerLink_Click(object sender, EventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.ShowDialog();
        }

        private void ReadSingleRow(IDataRecord record, string role)
        {
            try
            {
                globalUserID = Convert.ToInt32(record["ID"]);
                PageHelper.id = globalUserID;
                globalUsername = record["Email"].ToString();
                globalFirstName = record["FirstName"].ToString();
                globalLastName = record["LastName"].ToString();

                if (role.Equals("Employer"))
                    globalCompanyName = record["CompanyName"].ToString();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        //Temp
        private void rbEmployer_CheckedChanged(object sender, EventArgs e)
        {
            tbUsername.Text = "chrisTest@gmail.com";
            tbPassword.Text = "@Test123";
        }

        //Temp
        private void rbJobSeeker_CheckedChanged(object sender, EventArgs e)
        {
            tbUsername.Text = "JohnDoe1@kubra.com";
            tbPassword.Text = "john123";
        }

        private void getResumeWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                EmployerApi.StartAsync("GET_JobSeeker_Resume", PageHelper.id);
                if (EmployerApi.GetResume() != null)
                {
                    var jobSeekerResume = EmployerApi.GetResume();
                    PageHelper.resumeTitle = tbUsername.Text;
                    PageHelper.resumeId = jobSeekerResume.ID;
                    PageHelper.resumeDescription = jobSeekerResume.Description;
                    PageHelper.resumeSkills = jobSeekerResume.SkillSet;
                    PageHelper.resumeSubId = jobSeekerResume.SubID;
                    PageHelper.resumePresent = true;
                }
            }
            catch (Exception ex)
            {
                //throw detailed error here
            }
        }
    }
}
