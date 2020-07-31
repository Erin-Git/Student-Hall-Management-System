using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int StudentHallID { get; set; }
        public String StudentName { get; set; }
        public string Department { get; set; }
        public string RoomName { get; set; }
        public double FeeAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
