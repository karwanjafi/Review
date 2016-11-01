namespace Review.Model.CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Address
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string AddressLine1 { get; set; }

        [Required]
        [StringLength(200)]
        public string AddressLine2 { get; set; }

        [Required]
        [StringLength(20)]
        public string PostCode { get; set; }

        [Required]
        [StringLength(20)]
        public string TelNo { get; set; }

        [Required]
        [StringLength(20)]
        public string FaxNo { get; set; }

        [Required]
        public DbGeography Location { get; set; }

        public int City_Id { get; set; }

        public Guid? Business_Id { get; set; }

        public virtual Business Business { get; set; }

        public virtual City City { get; set; }
    }
}
