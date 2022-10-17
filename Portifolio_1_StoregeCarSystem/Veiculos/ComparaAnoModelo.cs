namespace Portifolio_1_StoregeCarSystem.Veiculos
{
    internal class ComparaAnoModelo : IComparer<VeiculosBase>
    {
        public int Compare(VeiculosBase? x, VeiculosBase? y)
        {
            if (x.AnoModelo == y.AnoModelo)
                return 0;
            if (x.AnoModelo > y.AnoModelo)
                return 1;
            return -1;
        }
    }
}