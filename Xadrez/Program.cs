using System;
using Tabuleiro;
using JogoXadrez;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Tab tabuleiro = new Tab(8, 8);

            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca) , new Posicao(1, 1));
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta) , new Posicao(2, 2));
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Branca) , new Posicao(3, 3));

            Tela.imprimirTabuleiro(tabuleiro);

            Console.WriteLine();
        }
    }
}
