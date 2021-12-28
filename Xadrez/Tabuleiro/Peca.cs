using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimento { get; protected set; }
        public Tab Tab { get; protected set; }

        public Peca(Cor cor, Tab tab)
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QtdMovimento = 0;
            
        }
    }
}
