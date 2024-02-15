using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class Ilgialani
    {
        [Key]
        public int Id { get; set; }
        public string Classadi { get; set; }
        public string Ilgiadi { get; set; }
        public string Renkkodu { get; set; }
    }
}