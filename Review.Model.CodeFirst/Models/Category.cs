namespace Review.Model.CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public Category()
        {
            Categories1 = new HashSet<Category>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public short Status { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public string Logo { get; set; }

        public int? Parent_Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Categories1 { get; set; }

        public virtual Category Category1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
