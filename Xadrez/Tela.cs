using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;
using JogoXadrez;

namespace Xadrez
{
    class Tela
    {
        public static void imprimirTabuleiro(Tab tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(8 - i + " ");
                Console.ResetColor();
                for (int x = 0; x < tab.Colunas; x++)
                {
                    ImprimirPeca(tab.peca(i, x));

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
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
            Console.ForegroundColor = ConsoleColor.Blue;
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(peca);
                    Console.ForegroundColor = corSystem;
                }
                Console.Write(" ");
            }
        }
    }
}
