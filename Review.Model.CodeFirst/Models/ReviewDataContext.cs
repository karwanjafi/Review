namespace Review.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class ReviewDataContext : IdentityDbContext<User, Role, string, UserLogin, UserRole, UserClaim>
    {
        public ReviewDataContext()
            : base("name=ReviewDataContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ScoreBand> ScoreBands { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Reviewer> Reviewer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Business>()
                .HasMany(e => e.Addresses)
                .WithOptional(e => e.Business)
                .HasForeignKey(e => e.Business_Id);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Business)
                .HasForeignKey(e => e.Business_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.Owners)
                .WithMany(e => e.Businesess)
                .Map(m => m.ToTable("BusinessOwner").MapLeftKey("Business_Id").MapRightKey("Owner_Id"));

            modelBuilder.Entity<Business>()
                .HasRequired(e => e.Tag)
                .WithOptional(e => e.Business);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Children)
                .WithOptional(e => e.Parent)
                .HasForeignKey(e => e.Parent_Id);

            modelBuilder.Entity<Category>()
                           .HasRequired(e => e.Tag)
                           .WithOptional(e => e.Category);

            modelBuilder.Entity<Address>()
                        .HasRequired(e => e.Tag)
                        .WithOptional(e => e.Address);

            modelBuilder.Entity<Review>()
                      .HasRequired(e => e.Tag)
                      .WithOptional(e => e.Review);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.City_Id)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.Country_Id)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ScoreBand>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.ScoreBand)
                .HasForeignKey(e => e.ScoreBand_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Admin)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Owner)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Reviewer)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete();


        }

        public static ReviewDataContext Create()
        {
            return new ReviewDataContext();
        }
    }
}
