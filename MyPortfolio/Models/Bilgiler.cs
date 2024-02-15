using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class Bilgiler
    {
        [Key]
        public int Id { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }

    }
}