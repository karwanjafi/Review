namespace Review.Model 
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ScoreBand
    {
        public ScoreBand()
        {
            Reviews = new HashSet<Review>();
        }

        public short Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Star { get; set; }

        [Required]
        public string Score { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
