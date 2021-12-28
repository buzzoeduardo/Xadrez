using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace JogoXadrez
{
    class Rei : Peca
    {
        public Rei(Tab tab, Cor cor) : base (cor, tab)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
