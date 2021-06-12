using Doctors.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctors.Database
{
    public class DContext : DbContext
    {
        public DContext(DbContextOptions<DContext> options) : base(options)
        {
        }
        public DbSet<DoctorModel> doctors { get; set; }
    }
}
