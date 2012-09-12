using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cardMage.Models
{
    public class Baralho
    {
        [Key]
        public string Nome { get; set; }
        public int HeroiID { get; set; }
        public IEnumerable<int> Cartas { get; set; }
    }
}