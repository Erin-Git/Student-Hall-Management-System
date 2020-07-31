using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.Models
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int RoomCapacity { get; set; }
    }
}
