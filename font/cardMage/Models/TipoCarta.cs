using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cardMage.Models
{
    public class TipoCarta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Tipo { get; set; }
    }
}