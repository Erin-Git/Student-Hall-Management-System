using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.ViewModels
{
    public class MealPaymentViewModel
    {
        public int mealpaymentidVM { get; set; }
        public int mealidVM { get; set; }
        public int studenthallidVM { get; set; }
        public int studentidVM { get; set; }
        public String studentnameVM { get; set; }
        public string departmentVM { get; set; }
        public double mealchargeVM { get; set; }
        public DateTime dateVM { get; set; }
    }
}
