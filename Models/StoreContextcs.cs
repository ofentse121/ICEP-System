using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ICEP_System.Models
{
    public class StoreContextcs:DbContext
    {
        public DbSet<Bus> Buss { get; set; }
        public DbSet<BusDriver> BussDriver { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}