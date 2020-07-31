using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHallManagement.Database;
using StudentHallManagement.Models;
using StudentHallManagement.ViewModels;

namespace StudentHallManagement.Controllers
{
    public class SupervisorController : Controller
    {
        private readonly DBClass dbc;
        public SupervisorController(DBClass DBC)
        {
            dbc = DBC;
        }
        public IActionResult Supervisor()
        {
            if(HttpContext.Session.GetString("UserRoleID") == "1")
            {
                return View();
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddNewStudent()
        {
            if (HttpContext.Session.GetString("UserRoleID") == "1")
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddNewStudent(StudentViewModel student)
        {
            Student s = new Student();
            s.StudentName = student.studentnameVM;
            s.Department = student.departmentVM;
            s.DOB = student.dobVM;
            s.ContactNo = student.contactnoVM;
            s.Date = DateTime.Now;
            dbc.Student.Add(s);
            dbc.SaveChanges();
            ModelState.Clear();
            User u = new User();
            u.UserID = s.StudentHallID;
            u.UserRoleID = 2;
            u.UserName = student.studentnameVM;
            u.Password=  54321;
            dbc.User.Add(u);
            dbc.SaveChanges();
            return View();
        }
        public IActionResult StudentList()
        {
            int serialno = 1;
            var s = dbc.Student.ToList();
            var liststudentviewmodel = new List<StudentViewModel>();
            foreach (var item in s)
            {
                StudentViewModel svm = new StudentViewModel();
                svm.serialnoVM = serialno;
                serialno++;
                svm.studenthallidVM = item.StudentHallID;
                svm.dobdVM = item.DOB.ToShortDateString();
                svm.dobVM = item.DOB;
                svm.studentnameVM = item.StudentName;
                svm.departmentVM = item.Department;
                svm.contactnoVM = item.ContactNo;
                liststudentviewmodel.Add(svm);
            }
            return View(liststudentviewmodel);
        }
        public IActionResult UpdateStudent(int idupdatestudent)
        {
            var s = dbc.Student.Where(q => q.StudentHallID == idupdatestudent).FirstOrDefault();
            StudentViewModel svm = new StudentViewModel();
            svm.studenthallidVM = idupdatestudent;
            svm.dobVM = s.DOB;
            svm.studentnameVM = s.StudentName;
            svm.departmentVM = s.Department;
            svm.contactnoVM = s.ContactNo;
            svm.dateVM = s.Date;
            return View(svm);
        }
        [HttpPost]
        public IActionResult UpdateStudent(StudentViewModel update)
        {
            Student s = new Student();
            s.StudentHallID = update.studenthallidVM;
            s.DOB = update.dobVM;
            s.StudentName = update.studentnameVM;
            s.Department = update.departmentVM;
            s.ContactNo = update.contactnoVM;
            s.Date = DateTime.Now;
            dbc.Student.Update(s);
            dbc.SaveChanges();
            ModelState.Clear();
            var x = dbc.User.Where(q => q.UserID == update.studenthallidVM).FirstOrDefault();
            if(x!=null)
            {
                x.UserName = update.studentnameVM;
                dbc.User.Update(x);
                dbc.SaveChanges();
            }
            else
            {
                return RedirectToAction("StudentList");
            }
            var y = dbc.Payment.Where(q => q.StudentHallID == update.studenthallidVM).FirstOrDefault();
            if (y != null)
            {
                y.StudentName = update.studentnameVM;
                y.Department = update.departmentVM;
                dbc.Payment.Update(y);
                dbc.SaveChanges();
            }
            else
            {
                return RedirectToAction("StudentList");
            }
            var z = dbc.AssignedRoom.Where(q => q.StudentHallID == update.studenthallidVM).FirstOrDefault();
            if (z != null)
            {
                z.StudentName = update.studentnameVM;
                z.Department = update.departmentVM;
                dbc.AssignedRoom.Update(z);
                dbc.SaveChanges();
            }
            var u = dbc.MealDistribution.Where(q => q.StudentHallID == update.studenthallidVM).ToList();
            if(u!=null)
            {
                foreach (var item in u)
                {
                    item.StudentName = update.studentnameVM;
                    dbc.MealDistribution.Update(item);
                    dbc.SaveChanges();
                }
            }
            else
            {
                return RedirectToAction("StudentList");
            }
            return RedirectToAction("StudentList");
        }

        public IActionResult RemoveStudent(int idremovestudent)
        {
            var s = dbc.Student.Where(q => q.StudentHallID == idremovestudent).FirstOrDefault();
            dbc.Student.Remove(s);
            dbc.SaveChanges();
            var d = dbc.User.Where(q => q.UserID == idremovestudent).FirstOrDefault();
            if(d!=null)
            {
                dbc.User.Remove(d);
                dbc.SaveChanges();
            }
            var x = dbc.Payment.Where(q => q.StudentHallID == idremovestudent).FirstOrDefault();
            if(x!=null)
            {
                dbc.Payment.Remove(x);
                dbc.SaveChanges();
            }
            else
            {
                return RedirectToAction("StudentList");
            }
            var y = dbc.MealDistribution.Where(q => q.StudentHallID == idremovestudent).ToList();
            if (y.Count != 0)
            {
                foreach (var item in y)
                {
                    dbc.MealDistribution.Remove(item);
                    dbc.SaveChanges();
                }               
            }
            else
            {
                return RedirectToAction("StudentList");
            }
            var z = dbc.AssignedRoom.Where(q => q.StudentHallID == idremovestudent).FirstOrDefault();
            if (z != null)
            {
                dbc.AssignedRoom.Remove(z);
                dbc.SaveChanges();
            }
            else
            {
                return RedirectToAction("StudentList");
            }
            return RedirectToAction("StudentList");
        }
        
        public IActionResult SetFee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetFee(FeeViewModel feeinfo)
        {
            Fee fee = new Fee();
            fee.FeeAmount = feeinfo.feeamountVM;
            dbc.Fee.Add(fee);
            dbc.SaveChanges();
            ModelState.Clear();
            return View();
        }
        public IActionResult FeeDetails()
        {
            int serialno= 1;
            var fee = dbc.Fee.ToList();
            var listoffee = new List<FeeViewModel>();
            foreach (var item in fee)
            {
                FeeViewModel feevm = new FeeViewModel();
                feevm.serialnoVM = serialno;
                serialno++;
                feevm.feeidVM = item.FeeID;
                feevm.feeamountVM = item.FeeAmount;
                listoffee.Add(feevm);
            }
            return View(listoffee);
        }
        public IActionResult UpdateFee(int feeupdateid)
        {
            var feeid = dbc.Fee.Where(q => q.FeeID == feeupdateid).FirstOrDefault();
            FeeViewModel feevm = new FeeViewModel();
            feevm.feeidVM = feeupdateid;
            feevm.feeamountVM = feeid.FeeAmount;
            return View(feevm);
        }
        [HttpPost]
        public IActionResult UpdateFee(FeeViewModel feeupdate)
        {
            Fee fee = new Fee();
            fee.FeeID = feeupdate.feeidVM;
            fee.FeeAmount = feeupdate.feeamountVM;
            dbc.Fee.Update(fee);
            dbc.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("FeeDetails");
        }
        public IActionResult Payment(FeeViewModel updatefee)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Payment(PaymentViewModel paymentid)
        {
            
            var check1 = dbc.Student.Where(q => q.StudentHallID == paymentid.studenthallidVM).FirstOrDefault();
            if(check1==null)
            {
                ViewBag.message1 = "Invalid ID";
            }
            else
            {
                var check2 = dbc.Payment.Where(q => q.StudentHallID == paymentid.studenthallidVM).FirstOrDefault();
                if(check2==null)
                {
                    return RedirectToAction("PaymentSubmission", new { studenthallid = paymentid.studenthallidVM });
                }
                else
                {
                    var check3 = dbc.Payment.Where(q => q.Date.Month != DateTime.Now.Month).FirstOrDefault();
                    if(check3!=null)
                    {
                        return RedirectToAction("PaymentSubmission", new { studenthallid = paymentid.studenthallidVM });
                    }
                    else
                    {
                        ViewBag.message2 = "Already paid for this month";
                    }
                }
            }
            return View();
        }
        public IActionResult PaymentSubmission(int studenthallid)
        {
            var studentinfo = dbc.Student.Where(q => q.StudentHallID == studenthallid).ToList();
            var feeamount = dbc.Fee.ToList();
            var query = (from qstudentinfo in studentinfo
                         from qfeeamount in feeamount
                         select new
                         {
                             hallid=qstudentinfo.StudentHallID,
                             name=qstudentinfo.StudentName,
                             department = qstudentinfo.Department,
                             fees=qfeeamount.FeeAmount
                         }).FirstOrDefault();
            PaymentViewModel paymentdetails = new PaymentViewModel();
            paymentdetails.studenthallidVM = query.hallid;
            paymentdetails.studentnameVM = query.name;
            paymentdetails.departmentVM = query.department;
            paymentdetails.feeamountVM = query.fees;
            paymentdetails.dateVM = DateTime.Now;
            return View(paymentdetails);
        }
        [HttpPost]
        public IActionResult PaymentSubmission(PaymentViewModel submission)
        {
            Payment submit = new Payment();
            submit.StudentHallID = submission.studenthallidVM;
            submit.StudentName = submission.studentnameVM;
            submit.Department = submission.departmentVM;
            submit.FeeAmount = submission.feeamountVM;
            submit.Date = submission.dateVM;
            dbc.Payment.Add(submit);
            dbc.SaveChanges();
            return RedirectToAction("Payment");
        }
        public IActionResult PaymentList()
        {
            int serialno = 1;
            var payment = dbc.Payment.Where(q=>q.Date.Month==DateTime.Now.Month).ToList();
            var paymentlist = new List<PaymentViewModel>();
            foreach (var item in payment)
            {
                PaymentViewModel paymentvm = new PaymentViewModel();
                paymentvm.serialnoVM = serialno;
                serialno++;
                paymentvm.studenthallidVM = item.StudentHallID;
                paymentvm.studentnameVM = item.StudentName;
                paymentvm.departmentVM = item.Department;
                paymentvm.feeamountVM = item.FeeAmount;
                paymentvm.dVM = item.Date.ToShortDateString();
                paymentlist.Add(paymentvm);
            }
            return View(paymentlist);
        }
        public IActionResult ChooseMealHour()
        {
           
            return View();
        }

        public IActionResult BreakfastHour()
        {
            int serialno = 1;
            
            var student = dbc.Payment.Where(q=>q.Date.Month==DateTime.Now.Month).ToList();
            var listmealdistribution = new List<MealDistributionViewModel>();
            foreach (var item in student)
            {
                MealDistributionViewModel distribution = new MealDistributionViewModel();
                distribution.serialnoVM = serialno;
                serialno++;
                distribution.studenthallidVM = item.StudentHallID;
                distribution.studentnameVM = item.StudentName;
                distribution.dateVM = DateTime.Now;
                listmealdistribution.Add(distribution);
            }
            
            return View(listmealdistribution);
        }
        [HttpPost]
        public IActionResult BreakfastHour(List<MealDistributionViewModel> distributuioninfo)
        {
            for(int i =0;i<distributuioninfo.Count;i++)
            {
                MealDistribution distribution = new MealDistribution();
                distribution.StudentHallID = distributuioninfo[i].studenthallidVM;
                distribution.StudentName = distributuioninfo[i].studentnameVM;
                distribution.MealCatagory = distributuioninfo[i].mealcatagoryVM;
                distribution.Date = DateTime.Now;
                if (distributuioninfo[i].distributionstatusVM == "1")
                {
                    distribution.DistributionStatus = true;
                }
                else
                {
                    distribution.DistributionStatus = false;
                }
                dbc.MealDistribution.Add(distribution);
                dbc.SaveChanges();
            }
            return RedirectToAction("ChooseMealHour");
        }
        public IActionResult LunchHour()
        {
            int serialno = 1;
            var student = dbc.Payment.Where(q => q.Date.Month == DateTime.Now.Month).ToList();
            var listmealdistribution = new List<MealDistributionViewModel>();
            foreach (var item in student)
            {
                MealDistributionViewModel distribution = new MealDistributionViewModel();
                distribution.serialnoVM = serialno;
                serialno++;
                distribution.studenthallidVM = item.StudentHallID;
                distribution.studentnameVM = item.StudentName;
                distribution.dateVM = DateTime.Now;
                listmealdistribution.Add(distribution);
            }
            return View(listmealdistribution);
        }
        [HttpPost]
        public IActionResult LunchHour(List<MealDistributionViewModel> distributuioninfo)
        {
            for (int i = 0; i < distributuioninfo.Count; i++)
            {
                MealDistribution distribution = new MealDistribution();
                distribution.StudentHallID = distributuioninfo[i].studenthallidVM;
                distribution.StudentName = distributuioninfo[i].studentnameVM;
                distribution.MealCatagory = distributuioninfo[i].mealcatagoryVM;
                distribution.Date = DateTime.Now;
                if (distributuioninfo[i].distributionstatusVM == "1")
                {
                    distribution.DistributionStatus = true;
                }
                else
                {
                    distribution.DistributionStatus = false;
                }
                dbc.MealDistribution.Add(distribution);
                dbc.SaveChanges();
            }
            return RedirectToAction("ChooseMealHour");
        }
        public IActionResult DinnerHour()
        {
            int serialno = 1;
            var student = dbc.Payment.Where(q => q.Date.Month == DateTime.Now.Month).ToList();
            var listmealdistribution = new List<MealDistributionViewModel>();
            foreach (var item in student)
            {
                MealDistributionViewModel distribution = new MealDistributionViewModel();
                distribution.serialnoVM = serialno;
                serialno++;
                distribution.studenthallidVM = item.StudentHallID;
                distribution.studentnameVM = item.StudentName;
                distribution.dateVM = DateTime.Now;
                listmealdistribution.Add(distribution);
            }
            return View(listmealdistribution);
        }
        [HttpPost]
        public IActionResult DinnerHour(List<MealDistributionViewModel> distributuioninfo)
        {
            for (int i = 0; i < distributuioninfo.Count; i++)
            {
                MealDistribution distribution = new MealDistribution();
                distribution.StudentHallID = distributuioninfo[i].studenthallidVM;
                distribution.StudentName = distributuioninfo[i].studentnameVM;
                distribution.MealCatagory = distributuioninfo[i].mealcatagoryVM;
                distribution.Date = DateTime.Now;
                if (distributuioninfo[i].distributionstatusVM == "1")
                {
                    distribution.DistributionStatus = true;
                }
                else
                {
                    distribution.DistributionStatus = false;
                }
                dbc.MealDistribution.Add(distribution);
                dbc.SaveChanges();
            }
            return RedirectToAction("ChooseMealHour");
        }

        public IActionResult DistributionDetails()
        {
            int serialno = 1;
            var distributioninfo = dbc.MealDistribution.Where(q=>q.Date.Month==DateTime.Now.Month).ToList();
            var count =( from d in distributioninfo
                        group d by (d.StudentHallID) into dl
                        from a in dl 
                        select new
                        {
                            id = dl.Key,
                            name=a.StudentName,                           
                            total = dl.Count(),
                            totaltrue = dl.Count(q=>q.DistributionStatus==true),
                            totalfalse = dl.Count(q=>q.DistributionStatus==false),                              
                        }).Distinct();           
            var list = new List<MealDistributionViewModel>();
            foreach (var item in count)
            {
                MealDistributionViewModel distributionvm = new MealDistributionViewModel();
                distributionvm.serialnoVM = serialno;
                serialno++;
                distributionvm.studenthallidVM = item.id;
                distributionvm.studentnameVM = item.name;
                distributionvm.status2 = (item.totaltrue*100)/item.total;
                distributionvm.meal = item.total;
                list.Add(distributionvm);
            }
            return View(list);
        }
        public IActionResult CreateNewRoom()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewRoom(RoomViewModel roominfo)
        {
            Room room = new Room();
            room.RoomName = roominfo.roomnameVM;
            room.RoomCapacity = roominfo.roomcapacityVM;
            dbc.Room.Add(room);
            dbc.SaveChanges();
            ModelState.Clear();
            var availableroom = dbc.Room.LastOrDefault();
            AvailableRoom available = new AvailableRoom();
            available.RoomID = availableroom.RoomID;
            available.RoomName = availableroom.RoomName;
            available.Available = availableroom.RoomCapacity;
            dbc.AvailableRoom.Add(available);
            dbc.SaveChanges();
            return RedirectToAction("RoomList");
        }
        public IActionResult RoomList()
        {
            int serialno = 1;
            //var availableroom = dbc.AssignedRoom.ToList();
            var room = dbc.Room.ToList();
            var availability = dbc.AvailableRoom.ToList();
            if(availability.Count==0)
            {
                var roomlist1 = new List<RoomViewModel>();
                foreach (var item in room)
                {
                    RoomViewModel roomvm = new RoomViewModel();
                    roomvm.serialnoVM = serialno;
                    serialno++;
                    roomvm.roomidVM = item.RoomID;
                    roomvm.availablilityVM = item.RoomCapacity;
                    roomvm.roomnameVM = item.RoomName;
                    roomvm.roomcapacityVM = item.RoomCapacity;
                    roomlist1.Add(roomvm);
                }
                return View(roomlist1);
            }
            else
            {
                var query = from r in room
                             join a in availability on r.RoomID equals a.RoomID
                             select new
                             {
                                 id = r.RoomID,
                                 name = r.RoomName,
                                 capacity = r.RoomCapacity,
                                 available = a.Available
                             };
                var roomlist = new List<RoomViewModel>();
                foreach (var item in query)
                {
                    RoomViewModel roomvm = new RoomViewModel();
                    roomvm.serialnoVM = serialno;
                    serialno++;
                    roomvm.roomidVM = item.id;
                    roomvm.availablilityVM = item.available;
                    roomvm.roomnameVM = item.name;
                    roomvm.roomcapacityVM = item.capacity;
                    roomlist.Add(roomvm);
                }
                return View(roomlist);
            }
        }
        public IActionResult UpdateRoom(int idupdateroom)
        {
            var check = dbc.Room.Where(q => q.RoomID == idupdateroom).FirstOrDefault();
            var check2 = dbc.AvailableRoom.Where(q => q.RoomID == idupdateroom).FirstOrDefault();
            RoomViewModel room = new RoomViewModel();
            room.roomidVM = idupdateroom;
            room.roomnameVM = check.RoomName;
            room.roomcapacityVM = check.RoomCapacity;
            room.availableroomidVM = check2.AvailableRoomID;
            return View(room);
        }
        [HttpPost]
        public IActionResult UpdateRoom(RoomViewModel update)
        {
            var x = dbc.Room.Where(q => q.RoomID == update.roomidVM).FirstOrDefault();
            var c = dbc.AvailableRoom.Where(q => q.RoomID == update.roomidVM).FirstOrDefault();
            c.Available = (update.roomcapacityVM - x.RoomCapacity)+c.Available ;
            dbc.AvailableRoom.Update(c);
            dbc.SaveChanges();
            //Room room = new Room();
            //room.RoomID = update.roomidVM;
            //room.RoomName = update.roomnameVM;
            //room.RoomCapacity = update.roomcapacityVM;
            x.RoomName = update.roomnameVM;
            x.RoomCapacity = update.roomcapacityVM;
            dbc.Room.Update(x);
            dbc.SaveChanges();
            ModelState.Clear();
            //var c = dbc.AvailableRoom.Where(q => q.RoomID == update.roomidVM).FirstOrDefault();
            //AvailableRoom available = new AvailableRoom();
            //available.AvailableRoomID = update.availableroomidVM;
            //available.RoomID = update.roomidVM;
            //available.RoomName = update.roomnameVM;
            //c.Available = (update.roomcapacityVM-c.Available)+1;
            //available.Available = update.roomcapacityVM;
            return RedirectToAction("RoomList");

        }
        public IActionResult RoomAssignForm()
        {
                  var check1 = dbc.AvailableRoom.Where(q => q.Available >0).ToList();
                check1.Insert(0, new AvailableRoom { RoomID = 0, RoomName = "Choose Room" });
                ViewBag.chooseroom = check1;
                return View();
        }
        [HttpPost]
        public IActionResult RoomAssignForm(AssignedRoomViewModel assignforminfo)
        {
            var check1 = dbc.AvailableRoom.Where(q => q.Available > 0).ToList();
            check1.Insert(0, new AvailableRoom { RoomID = 0, RoomName = "Choose Room" });
            ViewBag.chooseroom = check1;
            if (assignforminfo.roomidVM == 0)
            {
                ViewBag.message3 = "Please choose a room!";
                return View();
            }
            var matchstudent = dbc.Student.Where(q => q.StudentHallID == assignforminfo.studenthallidVM).FirstOrDefault();
            if (matchstudent == null)
            {
                ViewBag.message1 = "Invalid ID";
                return View();
            }
           
                var checkifassigned = dbc.AssignedRoom.Where(q => q.StudentHallID == assignforminfo.studenthallidVM).FirstOrDefault();
                if (checkifassigned != null)
                {
                    ViewBag.message2 = "Already Assigned!";
                    return View();
                }              
               
                var getroomname = dbc.AvailableRoom.Where(q => q.RoomID == assignforminfo.roomidVM).FirstOrDefault();
                AssignedRoom assign = new AssignedRoom();
                assign.StudentHallID = assignforminfo.studenthallidVM;
                assign.StudentName = matchstudent.StudentName;
                assign.RoomID = assignforminfo.roomidVM;
                assign.RoomName = getroomname.RoomName;
                assign.Department = matchstudent.Department;
                assign.Date = DateTime.Now;
                dbc.AssignedRoom.Add(assign);
                dbc.SaveChanges();
                ModelState.Clear();
                var getroomname2 = dbc.AvailableRoom.Where(q => q.RoomID == assign.RoomID).FirstOrDefault();
                getroomname2.Available = getroomname2.Available - 1;
                dbc.AvailableRoom.Update(getroomname2);
                dbc.SaveChanges();
                return View();
            }

        public IActionResult AssignedRoomList()
        {
            int serialno = 1;
            var studentinfo = dbc.Student.ToList();
            var roominfo = dbc.AssignedRoom.ToList();
            var query = from student in studentinfo
                        join room in roominfo on student.StudentHallID equals room.StudentHallID
                        select new
                        {
                            roomid=room.RoomID,
                            roomname=room.RoomName,
                            studenthallid=student.StudentHallID,
                            studentname=student.StudentName,
                            department=student.Department,
                            date=room.Date
                        };
            var detailslist = new List<AssignedRoomViewModel>();
            foreach (var item in query)
            {
                AssignedRoomViewModel assignedroominfo = new AssignedRoomViewModel();
                assignedroominfo.serialnoVM = serialno;
                serialno++;
                assignedroominfo.roomidVM = item.roomid;
                assignedroominfo.roomnameVM = item.roomname;
                assignedroominfo.studenthallidVM = item.studenthallid;
                assignedroominfo.studentnameVM = item.studentname;
                assignedroominfo.departmentVM = item.department;
                assignedroominfo.adVM = item.date.ToShortDateString();
                detailslist.Add(assignedroominfo);
            }
            return View(detailslist);
        }
    }
}