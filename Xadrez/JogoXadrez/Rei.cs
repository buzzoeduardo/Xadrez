using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace JogoXadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez PartidaX;
        public Rei(Tab tab, Cor cor, PartidaDeXadrez partida) : base (cor, tab)
        {
            PartidaX = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        private bool TesteTorreRoque(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QtdMovimento == 0;
        }

        public override bool[,] MovimentoPossiveis()
        {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //diagonal superior direita
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //diagonal inferior direita
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna +1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //baixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //diagonal inferior esquerda
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //diagonal superior esquerda
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
            }

            //#jogada especial - roque
            if (QtdMovimento == 0 && !PartidaX.Xeque)
            {
                //#jogada especial - roque pequeno
                Posicao posTorre = new Posicao(pos.Linha, pos.Coluna + 3);
                if (TesteTorreRoque(posTorre))
                {
                    Posicao p1 = new Posicao(pos.Linha, pos.Coluna + 1);
                    Posicao p2 = new Posicao(pos.Linha, pos.Coluna + 2);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null)
                    {
                        matriz[pos.Linha, pos.Coluna + 2] = true;
                    }
                }

                //#jogada especial - roque grande
                Posicao posTorre2 = new Posicao(pos.Linha, pos.Coluna - 4);
                if (TesteTorreRoque(posTorre2))
                {
                    Posicao p1 = new Posicao(pos.Linha, pos.Coluna - 1);
                    Posicao p2 = new Posicao(pos.Linha, pos.Coluna - 2);
                    Posicao p3 = new Posicao(pos.Linha, pos.Coluna - 3);
                    if (Tab.peca(p1) == null && Tab.peca(p2) == null && Tab.peca(p3) == null)
                    {
                        matriz[pos.Linha, pos.Coluna - 2] = true;
                    }
                }
            }

            return matriz;
        }
    }
}
