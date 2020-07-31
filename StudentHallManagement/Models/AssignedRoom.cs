using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.Models
{
    public class AssignedRoom
    {
        [Key]
        public int AssignedRoomID { get; set; }
        public int StudentHallID { get; set; }
        public String StudentName { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string Department { get; set; }
        public DateTime Date { get; set; }
    }
}
