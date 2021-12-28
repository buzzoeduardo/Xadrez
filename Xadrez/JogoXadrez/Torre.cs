using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace JogoXadrez
{
    class Torre : Peca
    {
        public Torre(Tab tab, Cor cor) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}