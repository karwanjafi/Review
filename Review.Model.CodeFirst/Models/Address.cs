namespace Review.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Addresses")]
    public partial class Address
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string AddressLine1 { get; set; }

        [StringLength(200)]
        public string AddressLine2 { get; set; }

        [StringLength(20)]
        public string PostCode { get; set; }

        [StringLength(20)]
        public string TelNo { get; set; }

        [StringLength(20)]
        public string FaxNo { get; set; }

        public DbGeography Location { get; set; }

        public Guid? Business_Id { get; set; }

        public virtual Business Business { get; set; }

        [Required]
        public int City_Id { get; set; }

        public virtual City City { get; set; }

        public Guid Tag_Id { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
