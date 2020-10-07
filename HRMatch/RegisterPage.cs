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
    public partial class RegisterPage : Form
    {
        Employer fillerEmployerObject = new Employer { Email = "", FirstName = "", LastName = "", CompanyName = "", Password = "" };
        JobSeeker fillerJobSeekerObject = new JobSeeker { Email = "", FirstName = "", LastName = "", Password = "" };
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void lblGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (tbEmail.Text != null && tbPass != null && tbPassConfirm != null && tbFirstName != null && tbLastName != null)
            {
                if (!tbPass.Text.Equals(tbPassConfirm.Text))
                    MessageBox.Show("Password does not match. Please try again");
                else
                {
                    if (rbEmployer.Checked)
                    {
                        Employer employer = new Employer
                        {
                            Email = tbEmail.Text,
                            FirstName = tbFirstName.Text,
                            LastName = tbLastName.Text,
                            Password = tbPass.Text,
                            CompanyName = tbCompanyName.Text
                        };

                        AddProfile(employer, fillerJobSeekerObject);
                        MessageBox.Show("Employer has now been sucssesfully registered!");
                    }
                    else if (rbSeeker.Checked)
                    {
                        JobSeeker seeker = new JobSeeker
                        {
                            Email = tbEmail.Text,
                            FirstName = tbFirstName.Text,
                            LastName = tbLastName.Text,
                            Password = tbPass.Text
                        };
                        AddProfile(fillerEmployerObject, seeker);
                        MessageBox.Show("JobSeeker has now been sucssesfully registered!");
                    }
                }

            }
            else
                MessageBox.Show("Please fill in all fields");

        }

        private void AddProfile(Employer emp, JobSeeker seeker)
        {

            string connectionStrings = ConfigurationManager.ConnectionStrings["Test"].ToString();
            string insertQuery = "";
            if (rbEmployer.Checked)
            {
                //Query for insert
                insertQuery = @"insert into Employer_Profile values ('" + emp.Email +"','" + emp.FirstName + "','" 
                    + emp.LastName + "','" + emp.Password + "','" + emp.CompanyName + "')";
            }
            else if(rbSeeker.Checked)
            {
                insertQuery = @"insert into JobSeeker_Profile values ('" + seeker.Email + "','" + seeker.FirstName + "','"
                    + seeker.LastName + "','" + seeker.Password +  "')";
            }
            else
            {
                MessageBox.Show("Selection empty");
            }

            using(SqlConnection conn = new SqlConnection(connectionStrings))
            {
                conn.Open();
                using(SqlCommand command = new SqlCommand(insertQuery, conn))
                {
                    command.ExecuteNonQuery();
                }
            }

        }
    }
}
