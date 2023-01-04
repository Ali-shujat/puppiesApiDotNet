using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using puppiesApiDotNet.Model;

namespace puppiesApiDotNet.Data
{
    public class puppiesApiDotNetContext : DbContext
    {
        public puppiesApiDotNetContext (DbContextOptions<puppiesApiDotNetContext> options)
            : base(options)
        {
        }

        public DbSet<puppiesApiDotNet.Model.Puppy> Puppy { get; set; } = default!;
    }
}
