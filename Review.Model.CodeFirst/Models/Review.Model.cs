namespace Review.Model.CodeFirst.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReviewModel : DbContext
    {
        public ReviewModel()
            : base("name=MyDbContext")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<UserLoginHistory> Logins { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ScoreBand> ScoreBands { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Users_Admin> Users_Admin { get; set; }
        public virtual DbSet<Users_Owner> Users_Owner { get; set; }
        public virtual DbSet<Users_Reviewer> Users_Reviewer { get; set; }

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
                .HasMany(e => e.Tags)
                .WithOptional(e => e.Business)
                .HasForeignKey(e => e.Business_Id);

            modelBuilder.Entity<Business>()
                .HasMany(e => e.Users_Owner)
                .WithMany(e => e.Businesses)
                .Map(m => m.ToTable("BusinessOwner").MapRightKey("Owners_Id"));

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Categories1)
                .WithOptional(e => e.Category1)
                .HasForeignKey(e => e.Parent_Id);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Tags)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.Category_Id);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.City_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.City_Id);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.Country_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.Location_Id);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Users_Reviewer)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.Country_Id);

            modelBuilder.Entity<Review>()
                .HasMany(e => e.Tags)
                .WithRequired(e => e.Review)
                .HasForeignKey(e => e.Review_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ScoreBand>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.ScoreBand)
                .HasForeignKey(e => e.ScoreBand_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Users_Admin)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Users_Owner)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Users_Reviewer)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Users_Reviewer>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Users_Reviewer)
                .HasForeignKey(e => e.Reviewer_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
              .HasMany(e => e.LoginHistory)
              .WithRequired(e => e.User)
              .HasForeignKey(e => e.UserId)
              .WillCascadeOnDelete(false);
        }
    }
}
