namespace Portifolio_1_StoregeCarSystem.Veiculos
{
    internal class ComparaPreco: IComparer<VeiculosBase>
    {
        public int Compare(VeiculosBase? x, VeiculosBase? y)
        {
            if(x.Valor == y.Valor)
                return 0;
            if(x.Valor > y.Valor) 
                return 1;
            return -1;
        }
    }
}