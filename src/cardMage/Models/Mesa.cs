using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cardMage.Models
{
    public class Mesa
    {
        private List<Carta> baralho;
        private List<Carta> mao;
        private List<Carta> cemiterio;
        private Carta heroi;

        public Mesa(List<Carta> baralhoInicial)
        {
            this.mao = new List<Carta>();
            this.cemiterio = new List<Carta>();

            this.baralho = baralhoInicial;
            Embaralhar();
        }

        public void Embaralhar()
        {
            Random rnd = new Random();
            for (int i = 0; i < baralho.Count; i++)
            {
                int j = rnd.Next(baralho.Count);
                Carta t = baralho[i];
                baralho[i] = baralho[j];
                baralho[j] = t;
            }
        }
    }
}
