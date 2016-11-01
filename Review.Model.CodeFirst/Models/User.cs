namespace Review.Model.CodeFirst.Models
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

    //IdentityUser<Guid, UserLoginHistory, UserRoleManager, UserClaim>,
    public partial class User : IdentityUser, IUser<string>
    {
        public User()
        {
            LoginHistory = new HashSet<UserLoginHistory>();
        }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Family { get; set; }

        public DateTime RegisterationDateTime { get; set; }

        public bool IsActivate { get; set; }

        public byte ActivationType { get; set; }

        public DateTime? ActivationDateTime { get; set; }

        public short Status { get; set; }

        [Required]
        public string Salt { get; set; }

        public Guid Login_Id { get; set; }

        public virtual ICollection<UserLoginHistory> LoginHistory { get; set; }

        public virtual Users_Admin Users_Admin { get; set; }

        public virtual Users_Owner Users_Owner { get; set; }

        public virtual Users_Reviewer Users_Reviewer { get; set; }

        string IUser<string>.Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
