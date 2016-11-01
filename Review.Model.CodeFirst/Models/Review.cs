namespace Review.Model.CodeFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Review()
        {
            Tags = new HashSet<Tag>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string SubmitDateTime { get; set; }

        [Required]
        public string SubmitIP { get; set; }

        [Required]
        public string SubmitLatitude { get; set; }

        [Required]
        public string SubmitLongitude { get; set; }

        [Required]
        public string IsConfirm { get; set; }

        public short Type { get; set; }

        public bool IsAnonymous { get; set; }

        public bool ToBlackList { get; set; }

        public short ScoreBand_Id { get; set; }

        public Guid Reviewer_Id { get; set; }

        public int? City_Id { get; set; }

        public int? Location_Id { get; set; }

        public Guid Business_Id { get; set; }

        public virtual Business Business { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        public virtual Users_Reviewer Users_Reviewer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ScoreBand ScoreBand { get; set; }
    }
}
