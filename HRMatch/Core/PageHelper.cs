using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMatch.Core
{
    public class PageHelper
    {

        public static int id { get; set; }
        public static int subId { get; set; }
        public static int resId { get; set; }
        public static bool isEmployer { get; set; }
        public static string globalDescription { get; set; }
        public static string globalTitle { get; set; }
        public static string globalSkills { get; set; }
        public static bool resumePresent { get; set; }

        public static string pageReferrer { get; set; }


        public static int resumeId { get; set; }
        public static int resumeSubId { get; set; }
        public static string resumeTitle { get; set; }
        public static string resumeDescription { get; set; }
        public static string resumeSkills { get; set; }

    }
}
