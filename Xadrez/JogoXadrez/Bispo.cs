﻿using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace JogoXadrez
{
    class Bispo : Peca
    {
        public Bispo(Tab tab, Cor cor) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentoPossiveis()
        {
            bool[,] matriz = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //diagona superior direita
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            //diagonal inferior direita
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            //diagonal inferior esquerda
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            //diagonal superior esquerda
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                matriz[pos.Linha, pos.Coluna] = true;
                if (Tab.peca(pos) != null && Tab.peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            return matriz;
        }
    }
}
