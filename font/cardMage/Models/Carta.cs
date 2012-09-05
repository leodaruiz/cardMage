using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace cardMage.Models
{
    public class Carta
    {
        [Key]
        public string Id { get; set; }

        [Required, MaxLength(55)]
        public string Nome { get; set; }

        [Required]
        public int TipoCartaID { get; set; }

        public string Descricao { get; set; }

        private string imagem;
        public string Imagem
        {
            get { return imagem; }
            set { imagem = "../../Images/Cartas/" + value; }
        }

        public decimal Ataque { get; set; }

        public decimal Defesa { get; set; }

        public Mana Custo { get; set; }
    }
}