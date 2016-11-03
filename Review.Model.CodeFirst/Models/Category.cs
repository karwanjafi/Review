namespace Review.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categories")]
    public partial class Category
    {
        public Category()
        {
            Children = new HashSet<Category>();
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
        public virtual Category Parent { get; set; }

        [Required]
        public Guid Tag_Id { get; set; }
        public virtual Tag Tag { get; set; }

        public virtual ICollection<Category> Children { get; set; }

    }
}