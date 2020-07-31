using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.Models
{
    public class Meal
    {
        [Key]
        public int MealID { get; set; }
        //public string MealCategory { get; set; }
        public double MealCharge { get; set; }
    }
}
