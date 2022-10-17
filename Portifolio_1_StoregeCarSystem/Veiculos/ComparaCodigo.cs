using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portifolio_1_StoregeCarSystem.Veiculos
{
    internal class ComparaCodigo : IComparer<VeiculosBase>
    {
        public int Compare(VeiculosBase? x, VeiculosBase? y)
        {
            if(x.Codigo == y.Codigo)
                return 0;
            if(x.Codigo > y.Codigo)
                return 1;
            return -1;
        }
    }
}
