using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    abstract class Peca
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

        public abstract bool[,] MovimentoPossiveis();
        
        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentoPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int x = 0; x < Tab.Colunas; x++)
                {
                    if (mat[i, x])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentoPossiveis()[pos.Linha, pos.Coluna];
        }

        public void IncrementarQtdMovimento()
        {
            QtdMovimento++;
        }
    }
}
