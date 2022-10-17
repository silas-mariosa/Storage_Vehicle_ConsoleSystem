using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Portifolio_1_StoregeCarSystem.Veiculos
{
    public class VeiculosBase : IEquatable<VeiculosBase>
    {
        private string _marca;
        private string _novoOuSeminovo;
        private int _kmRodados;
        private int _anoModelo;
        private int _anoFabricacao;
        private int _codigo;
        private int _valor;

        public int Valor { get { return _valor; } set { _valor = value; } }
        public string Marca { get { return _marca; } set { _marca = value; } }
        public string NovoOuSeminovo { get { return _novoOuSeminovo; } set { _novoOuSeminovo = value; } }
        public int KmRodados
        {
            get
            {
                return _kmRodados;
            }
            set
            {
                {
                    _kmRodados = value;
                }
            }
        }

        public int AnoModelo
        {
            get
            {
                return _anoModelo;
            }
            private set
            {
                {
                    _anoModelo = value;
                }
            }
        }

        public int AnoFabricacao
        {
            get
            {
                return _anoFabricacao;
            }
            set
            {
                _anoFabricacao = value;
            }
        }
        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                _codigo = value;
            }
        }


        public static int TotalDeVeiculos { get; private set; }
       

        public VeiculosBase(int cod, int km, int anomodelo, int anofab, string marca, string novoOuSeminovo, int valor)
        {
            Marca = marca;
            NovoOuSeminovo = novoOuSeminovo;
            Codigo = cod;
            KmRodados = km;
            AnoModelo = anomodelo;
            AnoFabricacao = anofab;
            Valor = valor;
            TotalDeVeiculos = TotalDeVeiculos + 1;

        }

        public VeiculosBase(string marca)
        {
            Marca = marca;
        }

        public override string ToString()
        {
            return $"=================================================\n" +
                   $"Código........: {this.Codigo}\n" +
                   $"Marca.........:{this.Marca}\n" +
                   $"Condição......: {this.NovoOuSeminovo}\n" +
                   $"Kilometrâgem..: {this.KmRodados}\n" +
                   $"Ano do modelo.: {this.AnoModelo}\n" +
                   $"Ano fabricação: {this.AnoFabricacao}\n" +
                   $"Valor.........: R$ {this.Valor},00\n";
                
;        }

        public bool Equals(VeiculosBase? other)
        {
            if(Marca == other.Marca)
            {
                return true;
            }
            return false;
        }

        public bool Equals1(VeiculosBase? other)
        {
            if (NovoOuSeminovo == other.NovoOuSeminovo)
            {
                return true;
            }
            return false;
        }
    }
}