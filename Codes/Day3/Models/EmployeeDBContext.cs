using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Models;
using Microsoft.EntityFrameworkCore;

namespace Task1.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
