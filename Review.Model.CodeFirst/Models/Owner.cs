namespace Review.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Owner
    {
        public Owner()
        {
            Businesess = new HashSet<Business>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string User_Id { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Business> Businesess { get; set; }

    }
}
