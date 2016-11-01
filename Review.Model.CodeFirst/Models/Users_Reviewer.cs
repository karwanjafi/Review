namespace Review.Model.CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users_Reviewer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users_Reviewer()
        {
            Reviews = new HashSet<Review>();
        }

        public Guid Id { get; set; }

        public byte RegisterationSource { get; set; }

        public DateTime? LastCommentDateTime { get; set; }

        public short Gender { get; set; }

        [Required]
        public string Bio { get; set; }

        [Required]
        public string BirthDay { get; set; }

        [Required]
        public string Interest { get; set; }

        public short EducationDegree { get; set; }


        public int? Country_Id { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual User User { get; set; }
    }
}
