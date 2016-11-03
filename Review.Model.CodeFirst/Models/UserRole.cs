namespace Review.Model
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;

    public class UserRole : IdentityUserRole<string>
    {
        [Key]
        public int Id { get; set; }

    }
}
