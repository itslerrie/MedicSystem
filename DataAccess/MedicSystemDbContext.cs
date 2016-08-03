using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataAccess
{
    public class MedicSystemDbContext<T> : DbContext where T : class
    {
        public MedicSystemDbContext()
            : base("name=MedicSystem.AppDbContext")
        {
        }

        public DbSet<T> Items { get; set; }

    }
}
