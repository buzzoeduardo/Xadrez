using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimento { get; protected set; }
        public Tab tab { get; protected set; }

        public Peca(Posicao posicao, Cor cor, Tab tab)
        {
            this.posicao = posicao;
            this.cor = cor;
            this.tab = tab;
            this.qtdMovimento = 0;
            
        }
    }
}
