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
    }
}
