using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Country
    {
        public int ID { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public string Capital { get; set; }
    }
}