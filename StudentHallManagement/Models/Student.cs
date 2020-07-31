using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentHallID { get; set; }
        public DateTime DOB { get; set; }
        public String StudentName { get; set; }
        public string Department { get; set; }
        public Int64 ContactNo { get; set; }
        public DateTime Date { get; set; }
    }
}
