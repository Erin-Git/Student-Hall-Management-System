using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.Models
{
    public class AvailableRoom
    {
        [Key]
        public int AvailableRoomID { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int Available { get; set; }
    }
}
