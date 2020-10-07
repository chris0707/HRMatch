using HRMatch.Core;
using HRMatch.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMatch.Api
{
    public class EmployerApi
    {
        public static HttpClient client = new HttpClient();

        //TODO: Call RunAsync that accepts a parameter 
        // Add SwitchCase statement to differentiate GET/POST/PUT/DELTE calls

        //static EmployerJobs employerJobs = null;
        static EmployerJob employerJob = null;
        static JobSeeker jobSeeker = null;
        static JobSeeker_Details jobSeeker_details = null;
        static JobSeeker_Resume jobSeeker_Resume = null;
        
        public static bool isSuccess = false;
        public static bool isPresent = false;
        static List<EmployerJob> employerJobs = null;
        static List<JobSeeker_Details> jobSeekers = null;
        static List<EmployerJob> jobs = new List<EmployerJob>();
        static HttpResponseMessage response;
        

        static EmployerJob empJob = new EmployerJob();

        public static void StartAsync(string requestType, int id = 1)
        {
            
            RunAsync(requestType, id).GetAwaiter().GetResult();
        }

        /***
         * id param can either be the "id" or "subid"
         * */
        static async Task RunAsync(string requestType, int id = 1)
        {
            try
            {
                if (client.BaseAddress == null)
                {
                    client.BaseAddress = new Uri("http://localhost:51781/");
                }
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var path = "";

                switch (requestType)
                {
                    case "GETALL":
                        //get all jobs for employers only
                        path = "api/values/GET/";
                        employerJobs = await GetEmpJobsAsync(path);
                        break;

                    case "GETALL_JobSeekers":
                        //get specific
                        path = "api/values/GetJobSeekers";
                        jobSeekers = await GetAllJobSeekerAsync(path);
                        break;

                    case "GETALL_PER_USER":
                        path = "api/values/GetJobs_User/" + id; //create param id
                        employerJobs = await GetAllJob_User(path);
                        break;

                    case "GET":
                        //get specific
                        path = "api/values/GET/" + id; //create param id
                        employerJob = await GetSingleEmpJobAsync(path);
                        break;

                    case "GET_JobSeeker_Profile_w_Resume":
                        path = "api/values/GetSeekerProfileRes/" + id;
                        jobSeeker_details = await GetSingleJobSeekerAsync(path);
                        break;

                    case "GET_JobSeeker_Resume":
                        path = "api/values/GetSeekerResume/" + id;
                        jobSeeker_Resume = await GetSingleResumeAsync(path);
                        break;

                    case "POST_JOB":
                        path = "api/values/PostJob";
                        isSuccess = await PostSingleEmpJobAsync(path, CreateJobPage.globalEmployerJob);
                        // add jobs
                        break;

                    case "POST_RESUME":
                        path = "api/values/PostRes";
                        isSuccess = await PostSingleEmpJobAsync(path, CreateJobPage.globalEmployerJob);
                        // add jobs
                        break;

                    case "PUT_JOB":
                        path = "api/values/PutJob";
                        isSuccess = await UpdateSingleEmpJob(path, ViewDetailsPartial.globalEmployerJob);
                        // add jobs
                        break;

                    case "PUT_RES":
                        path = "api/values/PutRes";
                        isSuccess = await UpdateSingleResume(path, ViewDetailsPartial.globalResume);
                        // add jobs
                        break;

                    case "DELETE_JOB":
                        path = "api/values/DeleteJob/" + id; //
                        isSuccess = await DeleteSingleEmpJobAsync(path, PageHelper.id);
                        // add jobs
                        break;

                    case "DELETE_RESUME":
                        path = "api/values/DeleteRes/" + id; //
                        isSuccess = await DeleteSingleEmpJobAsync(path, PageHelper.id);
                        // add jobs
                        break;



                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        static async Task<List<EmployerJob>> GetEmpJobsAsync(string path)
        {
            //EmployerJobs employerJobs = new EmployerJobs();

             response = await client.GetAsync(path);

            if(response.IsSuccessStatusCode)
            {
                var tempJobs = await response.Content.ReadAsStringAsync();
                employerJobs = JsonConvert.DeserializeObject<List<EmployerJob>>(tempJobs);
                
            }

            return employerJobs;
        }

        static async Task<List<JobSeeker_Details>> GetAllJobSeekerAsync(string path)
        {
            response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var tempSeekers = await response.Content.ReadAsStringAsync();
                jobSeekers = JsonConvert.DeserializeObject<List<JobSeeker_Details>>(tempSeekers);
            }

            return jobSeekers;
        }

        static async Task<EmployerJob> GetSingleEmpJobAsync(string path)
        {
            response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var tempJob = await response.Content.ReadAsStringAsync();
                employerJob = JsonConvert.DeserializeObject<EmployerJob>(tempJob);
            }

            return employerJob;
        }

        static async Task<JobSeeker_Details> GetSingleJobSeekerAsync(string path)
        {
            response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var tempSeeker = await response.Content.ReadAsStringAsync();
                jobSeeker_details = JsonConvert.DeserializeObject<JobSeeker_Details>(tempSeeker);
            }

            return jobSeeker_details;
        }

        static async Task<JobSeeker_Resume> GetSingleResumeAsync(string path)
        {
            response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var tempResume = await response.Content.ReadAsStringAsync();
                jobSeeker_Resume = JsonConvert.DeserializeObject<JobSeeker_Resume>(tempResume);
            }

            return jobSeeker_Resume;
        }

        static async Task<List<EmployerJob>> GetAllJob_User(string path)
        {
            response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var tempJobs = await response.Content.ReadAsStringAsync();
                employerJobs = JsonConvert.DeserializeObject<List<EmployerJob>>(tempJobs);
            }

            return employerJobs;
        }

        static async Task<Boolean> PostSingleEmpJobAsync(string path, EmployerJob employerJob)
        {
            response = await client.PostAsJsonAsync(path, employerJob);
            return response.IsSuccessStatusCode;

        }

        static async Task<Boolean> UpdateSingleEmpJob(string path, EmployerJob employerJob)
        {

            response = await client.PutAsJsonAsync(path, employerJob);
            return response.IsSuccessStatusCode;
        }

        static async Task<Boolean> UpdateSingleResume(string path, JobSeeker_Resume resume)
        {
            response = await client.PutAsJsonAsync(path, resume);
            return response.IsSuccessStatusCode;
        }

        static async Task<Boolean> DeleteSingleEmpJobAsync(string path, int id)
        {
            response = await client.DeleteAsync(path);
            return response.IsSuccessStatusCode;

        }

        public static List<object> GetList()
        {
            List<object> convertedList = new List<object>();
            if (employerJobs == null)
                return null;

            foreach (var a in employerJobs)
            {
                convertedList.Add(a);
            }

            return convertedList;
        }

        public static List<object> GetAllJobSeekerList()
        {
            List<object> seekers = new List<object>();
            if (jobSeekers == null)
                return null;

            foreach(var a in jobSeekers)
            {
                seekers.Add(a);
            }

            return seekers;
        }

        public static object GetSingle()
        {
            if (employerJob == null)
                return null;

            return employerJob;
        }

        public static object GetSingleSeeker()
        {
            if (jobSeeker_details == null)
                return null;

            return jobSeeker_details;
        }

        public bool GetPostStatus()
        {
            return isSuccess;
        }

        public static JobSeeker_Resume GetResume()
        {

            return jobSeeker_Resume;
        }
        public static bool GetPutStatus()
        {
            return isSuccess;
        }

        
    }
}
