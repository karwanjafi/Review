namespace Review.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }

        [Required]
        public DateTime SubmitDateTime { get; set; }

        [Required]
        [StringLength(15)]
        public string SubmitIP { get; set; }

        public decimal? SubmitLatitude { get; set; }

        public decimal? SubmitLongitude { get; set; }

        [Required]
        public bool IsConfirm { get; set; }

        public short Type { get; set; }

        [Required]
        public bool IsAnonymous { get; set; }

        [Required]
        public bool ToBlackList { get; set; }

        [Required]
        public Guid Reviewer_Id { get; set; }

        public int? Location_Id { get; set; }

        public Guid Business_Id { get; set; }
        public Guid Tag_Id { get; set; }
        public short ScoreBand_Id { get; set; }

        public virtual Business Business { get; set; }

        public virtual Reviewer Reviewer { get; set; }

        public virtual Tag Tag { get; set; }

        public virtual ScoreBand ScoreBand { get; set; }
    }
}
