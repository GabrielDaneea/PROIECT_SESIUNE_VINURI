using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROIECT_SESIUNE_VINURI.Pages.Models;

namespace PROIECT_SESIUNE_VINURI.Data
{
    public class PROIECT_SESIUNE_VINURIContext : DbContext
    {
        public PROIECT_SESIUNE_VINURIContext (DbContextOptions<PROIECT_SESIUNE_VINURIContext> options)
            : base(options)
        {
        }

        public DbSet<PROIECT_SESIUNE_VINURI.Pages.Models.Vin> Vin { get; set; } = default!;

        public DbSet<PROIECT_SESIUNE_VINURI.Pages.Models.Tara> Tara { get; set; }

        public DbSet<PROIECT_SESIUNE_VINURI.Pages.Models.Distribuitor> Distribuitor { get; set; }
    }
}
