using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace OpenMusic.API.Data
{
    public partial class OpenMusicDbContext : IdentityDbContext<ApplicationUser>
    {
        public OpenMusicDbContext(DbContextOptions<OpenMusicDbContext> options) : base (options)
        {
              
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

    }
    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
