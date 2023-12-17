using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajProje.Models
{
    public class StatisticsModel
    {
        
        public int TotalMembers { get; set; }
        public int MaleMembers { get; set; }
        public int FemaleMembers { get; set; }
        public double AverageAge { get; set; }
    }
}