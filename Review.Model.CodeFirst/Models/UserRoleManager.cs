using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Model.CodeFirst.Models
{
    public class UserRoleManager : IdentityUserRole<Guid>
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

    }
}
