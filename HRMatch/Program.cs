using HRMatch.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRMatch
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        static HttpClient client = new HttpClient();

        static void ShowProduct(EmployerJobs employerJobs)
        {
            foreach (EmployerJob employerJob in employerJobs.Jobs)
            {
                Console.WriteLine($"JobTitle: {employerJob.JobTitle}\tJob Description: " + $"{employerJob.Description}\tSkill Set: {employerJob.SkillSet}");
            }

        }

        static async Task<EmployerJobs> GetEmpJobAsync(string path)
        {
            EmployerJobs employerJobs = new EmployerJobs();
            
            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                var tempJobs = await response.Content.ReadAsStringAsync();
                employerJobs.Jobs = JsonConvert.DeserializeObject<List<EmployerJob>>(tempJobs);
            }

            return employerJobs;
        }
        
        [STAThread]
        static void Main()
        {
            //RunAsync().GetAwaiter().GetResult();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginPage());
            

        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:51781/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var path = "api/values";
            EmployerJobs employerJobs = null;

            try
            {
                employerJobs = await GetEmpJobAsync(path);
                ShowProduct(employerJobs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
