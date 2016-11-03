namespace Review.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Admin
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string User_Id { get; set; }

        public virtual User User { get; set; }
    }
}
