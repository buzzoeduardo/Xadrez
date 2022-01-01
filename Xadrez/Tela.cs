using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;
using JogoXadrez;

namespace Xadrez
{
    class Tela
    {

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            ImprimirPecaCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("TURNO: " + partida.turno);
            if (!partida.terminada)
            {
                Console.WriteLine("AGUARDANDO JOGADA DA PEÇA: " + partida.jogadorAtual);
                if (partida.Xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!!!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
        }

        public static void ImprimirPecaCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));            
            Console.Write("Pretas: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ResetColor();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }
        public static void imprimirTabuleiro(Tab tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(8 - i + " ");
                Console.ResetColor();
                for (int x = 0; x < tab.Colunas; x++)
                {
                    ImprimirPeca(tab.peca(i, x));

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  A B C D E F G H");
            Console.ResetColor();
        }

        public static void imprimirTabuleiro(Tab tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " ");
                Console.ResetColor();
                for (int x = 0; x < tab.Colunas; x++)
                {
                    if (posicoesPossiveis[i, x])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.peca(i, x));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  A B C D E F G H");
            Console.ResetColor();
            Console.BackgroundColor = fundoOriginal;
        }


        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor corSystem = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(peca);
                    Console.ForegroundColor = corSystem;
                }
                Console.Write(" ");
            }
        }
    }
}
