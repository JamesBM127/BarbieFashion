using BarbieFashion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarbieFashion.Data
{
    public class BarbieFashionContext : DbContext
    {
        public BarbieFashionContext (DbContextOptions<BarbieFashionContext> options)
            : base(options)
        {
        }

        public DbSet<InfoModel> InfoModels { get; set; }
        public DbSet<Parents> Parents { get; set; }
        public DbSet<BarbieFashion.Models.Agency> Agency { get; set; }
    }
}
