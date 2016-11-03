namespace Review.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Businesses")]
    public partial class Business
    {
        public Business()
        {
            Reviews = new HashSet<Review>();
            Owners = new HashSet<Owner>();
            Addresses = new HashSet<Address>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        public string Logo { get; set; }

        public string Bio { get; set; }

        public short AverageScore { get; set; }

        public DateTime? LastCalculationDateTime { get; set; }

        [Required]
        public Guid Tag_Id { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

    }
}
