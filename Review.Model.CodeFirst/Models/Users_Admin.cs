namespace Review.Model.CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users_Admin
    {
        public Guid Id { get; set; }

        public virtual User User { get; set; }
    }
}
