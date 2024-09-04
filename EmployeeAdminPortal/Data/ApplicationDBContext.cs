using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDBcontext : DbContext
    {
        //public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options): base(options) 
        //{

        //}
        //public ApplicationDBcontext() { }
        public ApplicationDBcontext(DbContextOptions options) : base(options)
        {

        }

        

        public DbSet<Employee> Employees { get; set; }
    }
}
