using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.Models
{
    public class MealDistribution
    {
        [Key]
        public int MealDistributionID { get; set; }
        public int StudentHallID { get; set; }
        public String StudentName { get; set; }
        public bool DistributionStatus { get; set; }
        public string MealCatagory { get; set; }
        public DateTime Date { get; set; }
    }
}
