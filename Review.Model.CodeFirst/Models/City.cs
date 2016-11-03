namespace Review.Model 
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
   

    [Table("Cities")]
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public short Status { get; set; } 

        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        public int Country_Id { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

    }
}
