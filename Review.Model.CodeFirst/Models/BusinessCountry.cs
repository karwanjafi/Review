namespace Review.Model 
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("UserCountries")]
    public class BusinessCountry
    {
        public User User { get; set; }
        public Country Country { get; set; }

    }
}
