using Microsoft.EntityFrameworkCore;
using StudentHallManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHallManagement.Database
{
    public class DBClass:DbContext
    {
        public DBClass(DbContextOptions<DBClass>options):base(options)
        {

        }
        public DbSet<Student> Student { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<AssignedRoom> AssignedRoom { get; set; }
        public DbSet<AvailableRoom> AvailableRoom { get; set; }
        public DbSet<Fee> Fee { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<MealDistribution> MealDistribution { get; set; }
    }
}
