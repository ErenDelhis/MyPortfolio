using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class Portfolio
    {
        [Key]
        public int Id { get; set; }
        public string Foto { get; set; }
        public string Tur { get; set; }
    }
}