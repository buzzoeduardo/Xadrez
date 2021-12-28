using System;
using Tabuleiro;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tab tabuleiro = new Tab(8, 8);

            Tela.imprimirTabuleiro(tabuleiro);

            Console.WriteLine();
        }
    }
}
