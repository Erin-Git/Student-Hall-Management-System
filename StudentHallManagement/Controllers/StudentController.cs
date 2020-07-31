using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHallManagement.Database;
using StudentHallManagement.ViewModels;

namespace StudentHallManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly DBClass dbc;
        public StudentController(DBClass DBC)
        {
            dbc = DBC;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyInfo()
        {
            var student = HttpContext.Session.GetString("UserID");
            var id = Convert.ToInt32(student);
            var s = dbc.Student.Where(q => q.StudentHallID == id).FirstOrDefault();
           
            StudentViewModel studentinfo = new StudentViewModel();
            studentinfo.studenthallidVM = s.StudentHallID;
            studentinfo.studentnameVM = s.StudentName;
            studentinfo.departmentVM = s.Department;
            studentinfo.contactnoVM = s.ContactNo;
            studentinfo.dobdVM = s.DOB.ToShortDateString();
            studentinfo.adVM = s.Date.ToShortDateString(); 
           
            return View(studentinfo);
        }
        public IActionResult MyRoomInfo()
        {
            var student = HttpContext.Session.GetString("UserID");
            var id = Convert.ToInt32(student);
            var c = dbc.AssignedRoom.Where(q => q.StudentHallID == id).FirstOrDefault();

            AssignedRoomViewModel assignedinfo = new AssignedRoomViewModel();
            assignedinfo.studenthallidVM = c.StudentHallID;
            assignedinfo.studentnameVM = c.StudentName;
            assignedinfo.roomnameVM = c.RoomName;
            assignedinfo.adVM = c.Date.ToShortDateString();
            return View(assignedinfo);
        }
        public IActionResult MyMealActivity()
        {
            var student = HttpContext.Session.GetString("UserID");
            var id = Convert.ToInt32(student);
            var c = dbc.MealDistribution.Where(q =>q.Date.Month==DateTime.Now.Month && q.StudentHallID == id).ToList();
            var count = (from i in c
                         group i by (i.StudentHallID) into l
                         from list in l
                         select new
                         {
                             id = list.StudentHallID,
                             name = list.StudentName,
                             total = l.Count(),
                             totaltrue = l.Count(q => q.DistributionStatus == true)
                         }).FirstOrDefault();
            MealDistributionViewModel status = new MealDistributionViewModel();
            status.studenthallidVM = count.id;
            status.studentnameVM = count.name;
            status.meal = count.total;
            status.status2 = (count.totaltrue * 100) / count.total;
            return View(status);
        }
    }
}