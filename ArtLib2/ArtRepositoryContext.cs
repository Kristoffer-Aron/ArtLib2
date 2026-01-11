using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLib2
{
    public class ArtRepositoryContext : DbContext
    {

        public ArtRepositoryContext(DbContextOptions<ArtRepositoryContext> options) : base(options)
        {
        }
        public DbSet<Art> ArtDB { get; set; }





    }
}
