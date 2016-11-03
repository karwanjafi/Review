using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.Model.CodeFirst.Models
{
    [Table("BusinessOwner")]
    public class BusinessOwner
    {
        public Guid Id { get; set; }
        public Guid Business_Id { get; set; }
        public virtual Business Business { get; set; }
        public Guid Owner_id { get; set; }
        public virtual Owner Owner { get; set; }

    }
}
