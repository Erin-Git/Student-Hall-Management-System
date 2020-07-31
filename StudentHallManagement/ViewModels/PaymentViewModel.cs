using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.ViewModels
{
    public class PaymentViewModel
    {
        public int serialnoVM { get; set; }
        public int paymentidVM { get; set; }
        public int studenthallidVM { get; set; }
        public String studentnameVM { get; set; }
        public string departmentVM { get; set; }
        public string roomnameVM { get; set; }
        public double feeamountVM { get; set; }
        public string dVM { get; set; }
        public DateTime dateVM { get; set; }
    }
}
