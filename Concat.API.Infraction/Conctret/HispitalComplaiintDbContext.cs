using Concat.API.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concat.API.Infraction.Conctret
{
    public class HispitalComplaiintDbContext:DbContext
    {
        public HispitalComplaiintDbContext(DbContextOptions<HispitalComplaiintDbContext> options) : base(options) { }
        public DbSet<HospitalComplaint> HospitalComplaints { get; set; }

    }
}
