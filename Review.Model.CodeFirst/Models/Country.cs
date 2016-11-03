namespace Review.Model 
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Countries")]
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
            Useres = new HashSet<User>();
            Businesses = new HashSet<Business>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(5)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public short Status { get; set; }

     

        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<User> Useres { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }
    }
}
