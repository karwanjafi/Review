namespace Review.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class UserLogin : IdentityUserLogin<string>
    {
        [Key]
        public int Id { get; set; }

    }
}
