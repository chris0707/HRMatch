﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMatch.Model
{
    public class EmployerJob
    {
        public int ID { get; set; }
        public int SubID { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string  SkillSet { get; set; }
    }
}
