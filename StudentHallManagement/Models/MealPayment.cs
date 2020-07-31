using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.Models
{
    public class MealPayment
    {
        [Key]
        public int MealPaymentID { get; set; }
        public int MealID { get; set; }
        public int StudentHallID { get; set; }
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public string Department { get; set; }
        public double MealCharge { get; set; }
        public DateTime Date { get; set; }
    }
}
