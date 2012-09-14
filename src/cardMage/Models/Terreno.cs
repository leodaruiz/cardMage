using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cardMage.Models
{
    public class Terreno : Carta
    {
        public Mana Mana { get; set; }
    }

    public class Pantano : Terreno 
    {
        public Pantano()
        {
            this.Mana = new Mana();
            this.Mana.Preta = 1;
        }
    }

    public class Planicie : Terreno
    {
        public Planicie()
        {
            this.Mana = new Mana();
            this.Mana.Branca = 1;
        }
    }
}