using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.Models
{
    public class Fee
    {
        [Key]
        public int FeeID { get; set; }
        public double FeeAmount { get; set; }
    }
}
