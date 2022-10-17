namespace Portifolio_1_StoregeCarSystem.Veiculos
{
    internal class ComparaAnoFab: IComparer<VeiculosBase>
    {
        public int Compare(VeiculosBase? x, VeiculosBase? y)
        {
            if (x.AnoFabricacao == y.AnoFabricacao)
                return 0;
            if (x.AnoFabricacao > y.AnoFabricacao)
                return 1;
            return -1;
        }
    }
}