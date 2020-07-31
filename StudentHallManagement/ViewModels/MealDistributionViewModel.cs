using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.ViewModels
{
    public class MealDistributionViewModel
    {
        public int serialnoVM { get; set; }
        public int mealdistributionidVM { get; set; }
        public int studenthallidVM { get; set; }
        public String studentnameVM { get; set; }
        public double status2 { get; set; }
        public int meal { get; set; }
        public string distributionstatusVM { get; set; }
        public string mealcatagoryVM { get; set; }
        public DateTime dateVM { get; set; }
    }
}
