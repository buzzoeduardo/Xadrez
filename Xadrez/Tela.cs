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
                Console.Write(8 - i + " ");
                for (int x = 0; x < tab.Colunas; x++)
                {                    
                    if (tab.peca(i, x) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPeca(tab.peca(i, x));
                        Console.Write(" ");
                    }                   
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
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
        }
    }
}
