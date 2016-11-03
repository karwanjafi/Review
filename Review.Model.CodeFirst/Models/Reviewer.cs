namespace Review.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reviewer
    {
        public Reviewer()
        {
            Reviews = new HashSet<Review>();
        }

        [Required]
        public string Id { get; set; }
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

        public virtual ICollection<Review> Reviews { get; set; }

        [Required]
        public string User_Id { get; set; }
        public virtual User User { get; set; }
    }
}
