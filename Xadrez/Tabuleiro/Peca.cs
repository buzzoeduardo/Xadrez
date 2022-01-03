namespace Tabuleiro{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimento { get; protected set; }
        public Tab Tab { get; protected set; }

        public Peca(Tab tab, Cor cor)
        {
            Posicao = null;
            Tab = tab;
            Cor = cor;            
            QtdMovimento = 0;            
        }
        public void IncrementarQtdMovimento()
        {
            QtdMovimento++;
        }
        public void DecrementarQtdMovimento()
        {
            QtdMovimento--;
        }
        
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

        public bool movimentoPossivel(Posicao pos)
        {
            return MovimentoPossiveis()[pos.Linha, pos.Coluna];
        }
        public abstract bool[,] MovimentoPossiveis();
    }
}
