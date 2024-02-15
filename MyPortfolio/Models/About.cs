using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Foto { get; set; }
        public string DogumGunu { get; set; }
        public string Tel { get; set; }
        public string Sehir { get; set; }
        public int Yas { get; set; }
        public string Derece { get; set; }
        public string Mail { get; set; }
        public string HakkimdaYazisi { get; set; }
        public string FreeLance { get; set; }
        public string Rutbe { get; set; }
    }
}