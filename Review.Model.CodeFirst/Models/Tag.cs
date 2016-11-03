namespace Review.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tag
    {
        public Guid Id { get; set; }

        [Required]
        public string TagName { get; set; }

        public bool Searchable { get; set; }

        public int? Category_Id { get; set; }

        public Guid? Business_Id { get; set; }

        public Guid? Review_Id { get; set; }
        public Guid? Address_Id { get; set; }

        public virtual Business Business { get; set; }

        public virtual Category Category { get; set; }

        public virtual Review Review { get; set; }

        public virtual Address Address { get; set; }
    }
}
