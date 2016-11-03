namespace Review.Model
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Table("Users")]
    public partial class User  : IdentityUser<string, UserLogin, UserRole, UserClaim>
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Family { get; set; }

        public DateTime RegisterationDateTime { get; set; }

        public bool IsActivate { get; set; }

        public DateTime? ActivationDateTime { get; set; }

        public short Status { get; set; }
  
        public virtual Admin Admin { get; set; }

        public virtual Owner Owner { get; set; }

        public virtual Reviewer Reviewer { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
