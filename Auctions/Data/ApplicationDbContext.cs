using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Auctions.Models;

namespace Auctions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Listing> Listings { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ListingVM> ListingsVMs { get; set; }
        public DbSet<Actu> Actus { get; set; }
        public DbSet<ActuVM> ActusVMs { get; set; }

        public DbSet<JeuxVideo> JeuxVideos { get; set; }
        public DbSet<Plateforme> Plateformes { get; set; }
        public DbSet<JeuxVideoPlateforme> JeuxVideoPlateformes { get; set; }
        public DbSet<JeuxVideoVM> JeuxVideosVMs { get; set; }
        //public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JeuxVideoPlateforme>()
                .HasKey(jvp => new { jvp.JeuxVideoId, jvp.PlateformeId });
            modelBuilder.Entity<JeuxVideoPlateforme>()
                .HasOne(jvp => jvp.JeuxVideo)
                .WithMany(jv => jv.JeuxVideoPlateformes)
                .HasForeignKey(jvp => jvp.JeuxVideoId);
            modelBuilder.Entity<JeuxVideoPlateforme>()
                .HasOne(jvp => jvp.Plateforme)
                .WithMany(p => p.JeuxVideoPlateformes)
                .HasForeignKey(jvp => jvp.PlateformeId);
            modelBuilder.Entity<JeuxVideo>()
                .HasMany(jv => jv.JeuxVideoPlateformes)
                .WithOne(jvp => jvp.JeuxVideo)
                .HasForeignKey(jvp => jvp.JeuxVideoId);
            modelBuilder.Entity<Plateforme>()
                .HasMany(p => p.JeuxVideoPlateformes)
                .WithOne(jvp => jvp.Plateforme)
                .HasForeignKey(jvp => jvp.PlateformeId);
            //modelBuilder.Entity<Plateforme>()
            //    .HasData(
            //        new Plateforme { Id = 1, Nom = "PC" },
            //        new Plateforme { Id = 2, Nom = "PS4" },
            //        new Plateforme { Id = 3, Nom = "Xbox One" },
            //        new Plateforme { Id = 4, Nom = "Switch" }
            //    );
            //modelBuilder.Entity<JeuxVideo>()
            //    .HasData(
            //        new JeuxVideo { Id = 1, Titre = "Cyberpunk 2077", Description = "super bon jeux", ImagePath = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ffr.tripadvisor.ca%2FRestaurants-g181733-c31-Brossard_Quebec.html&psig=AOvVaw3hUHWS986UP-e8wtSJ0uxa&ust=1731761632327000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCIi6pPmw3okDFQAAAAAdAAAAABAE" },
            //        new JeuxVideo { Id = 2, Titre = "The Witcher 3", Description = "super bon jeux", ImagePath = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ffr.tripadvisor.ca%2FRestaurants-g181733-c31-Brossard_Quebec.html&psig=AOvVaw3hUHWS986UP-e8wtSJ0uxa&ust=1731761632327000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCIi6pPmw3okDFQAAAAAdAAAAABAE" },
            //        new JeuxVideo { Id = 3, Titre = "GTA V", Description = "super bon jeux" , ImagePath = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ffr.tripadvisor.ca%2FRestaurants-g181733-c31-Brossard_Quebec.html&psig=AOvVaw3hUHWS986UP-e8wtSJ0uxa&ust=1731761632327000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCIi6pPmw3okDFQAAAAAdAAAAABAE" },
            //        new JeuxVideo { Id = 4, Titre = "Red Dead Redemption 2", Description = "super bon jeux", ImagePath = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ffr.tripadvisor.ca%2FRestaurants-g181733-c31-Brossard_Quebec.html&psig=AOvVaw3hUHWS986UP-e8wtSJ0uxa&ust=1731761632327000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCIi6pPmw3okDFQAAAAAdAAAAABAE" }
            //    );
            //modelBuilder.Entity<JeuxVideoPlateforme>()
            //    .HasData(
            //    new JeuxVideoPlateforme { JeuxVideoId = 1, PlateformeId = 1 },
            //    new JeuxVideoPlateforme { JeuxVideoId = 1, PlateformeId = 2 },
            //    new JeuxVideoPlateforme { JeuxVideoId = 1, PlateformeId = 3 },
            //    new JeuxVideoPlateforme { JeuxVideoId = 1, PlateformeId = 4 },
            //    new JeuxVideoPlateforme { JeuxVideoId = 2, PlateformeId = 1 },
            //    new JeuxVideoPlateforme { JeuxVideoId = 2, PlateformeId = 2 }
            //    );
        }


    }
}
