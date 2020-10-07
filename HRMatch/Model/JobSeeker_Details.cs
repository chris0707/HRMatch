using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMatch.Model
{
    class JobSeeker_Details
    {
        public int id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string SkillSet { get; set; }
        public int ResID { get; set; }
    }
}
