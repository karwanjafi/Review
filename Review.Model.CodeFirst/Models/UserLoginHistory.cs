namespace Review.Model.CodeFirst.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserLoginHistory : IdentityUserLogin<Guid>
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public DateTime LoginDateTime { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string TokenIp { get; set; }

        [Required]
        public string LoginDevice { get; set; }

        public Guid User_Id { get; set; }

        public virtual User User { get; set; }
    }
}
