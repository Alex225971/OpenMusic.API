using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using YamlDotNet.Core.Tokens;

namespace OpenMusic.API.Data;

public partial class OpenMusicDbContext : IdentityDbContext<ApplicationUser>
{
    public OpenMusicDbContext(DbContextOptions<OpenMusicDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Artist> Artists { get; set; }
    public virtual DbSet<Album> Albums { get; set; }
    public virtual DbSet<Song> Songs { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<AlbumGenre> AlbumGenres { get; set; }
    public DbSet<SongGenre> SongGenres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Album>()
            .HasOne(a => a.Artist)
            .WithMany(b => b.Albums)
            .HasForeignKey(a => a.ArtistId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Album>()
            .HasMany(a => a.AlbumGenres)
            .WithOne(ag => ag.Album);
        //    .HasForeignKey(ag => ag.GenreId);

        modelBuilder.Entity<Song>()
            .HasOne(s => s.Album)
            .WithMany(a => a.Songs)
            .HasForeignKey(s => s.AlbumId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Song>()
            .HasOne(s => s.Artist)
            .WithMany(a => a.Songs)
            .HasForeignKey(s => s.ArtistId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Song>()
            .HasMany(s => s.SongGenres)
            .WithOne(sg => sg.Song);
        //    .HasForeignKey(ag => ag.GenreId);


        modelBuilder.Entity<AlbumGenre>()
            .HasOne(ag => ag.Album)
            .WithMany(a => a.AlbumGenres)
            .HasForeignKey(ag => ag.AlbumId);

        modelBuilder.Entity<SongGenre>()
           .HasKey(sg => new { sg.SongId, sg.GenreId });

        modelBuilder.Entity<AlbumGenre>()
           .HasKey(sg => new { sg.AlbumId, sg.GenreId });

        modelBuilder.Entity<SongGenre>()
            .HasOne(sg => sg.Song)
            .WithMany(s => s.SongGenres)
            .HasForeignKey(sg => sg.SongId);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "8b80bb4a-bceb-4e48-b020-0b42da346212"
            },
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = "57f7dbef-2cf8-49c9-956a-3a9e16d6a0a5"
            }
        );

        var hasher = new PasswordHasher<ApplicationUser>();

        modelBuilder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "9f86d912-6254-44e6-aa64-d4da31c8a999",
                Email = "admin@test.com",
                NormalizedEmail = "ADMIN@TEST.COM",
                UserName = "admin@test.com",
                NormalizedUserName = "ADMIN@TEST.COM",
                FirstName = "System",
                LastName = "Admin",
                PasswordHash = hasher.HashPassword(null, "Jabberwocky1!")
            },
            new ApplicationUser
            {
                Id = "0017d7fe-f844-47fa-96b1-f6f3f280db0f",
                Email = "user@test.com",
                NormalizedEmail = "USER@TEST.COM",
                UserName = "user@test.com",
                NormalizedUserName = "USER@TEST.COM",
                FirstName = "System",
                LastName = "User",
                PasswordHash = hasher.HashPassword(null, "Jabberwocky1!")
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "8b80bb4a-bceb-4e48-b020-0b42da346212",
                UserId = "0017d7fe-f844-47fa-96b1-f6f3f280db0f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "57f7dbef-2cf8-49c9-956a-3a9e16d6a0a5",
                UserId = "9f86d912-6254-44e6-aa64-d4da31c8a999"
            }
        );

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}

