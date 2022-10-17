using Portifolio_1_StoregeCarSystem.Veiculos;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Portifolio_1_StoregeCarSystem.Atendimento
{
    public class Atendimento
    {
        public List<VeiculosBase> _Veiculos;
        public Atendimento()
        {
            _Veiculos = new List<VeiculosBase>();
            var enderecoDoArquivo = @"H:\Meu Drive\Doc Silas\Silas\Logica\Portifolios_Pessoais\Projeto_1_CS\Portifolio_1_StoregeCarSystem\Portifolio_1_StoregeCarSystem\Dat\veiculos.csv";
            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var leitor = new StreamReader(fluxoDeArquivo);
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    Console.WriteLine(linha);
                    var veiculo = ConverterStringParaVeiculosBase(linha);
                    _Veiculos.Add((VeiculosBase)veiculo);

                }
                object ConverterStringParaVeiculosBase(string? linha)
                {
                    var campos = linha.Split(';');
                    var _codigo = campos[0];
                    var _km = campos[1];
                    var _anomodelo = campos[2];
                    var _anofab = campos[3];
                    var _marca = campos[4];
                    var _novoOuSeminovo = campos[5];
                    var _valor = campos[6];//.Replace('.', ',');

                    var _codigoComInt = int.Parse(_codigo);
                    var _kmComInt = int.Parse(_km);
                    var _anoModeloComInt = int.Parse(_anomodelo);
                    var _anofabComInt = int.Parse(_anofab);
                    var _valorComint = int.Parse(_valor);

                    var resultado = new VeiculosBase(_codigoComInt, _kmComInt, _anoModeloComInt, _anofabComInt, _marca, _novoOuSeminovo, _valorComint);


                    return resultado;
                    }
                }
        }

        public static string lerNumeros()
        {
        ConsoleKeyInfo cki;
        string entrada = "";
        while (true)
        {
            if (Console.KeyAvailable)
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (entrada.Length == 0) continue;
                    entrada = entrada.Remove(entrada.Length - 1);
                    Console.Write("\b \b"); //Remove o último caractere digitado
                }
                if (cki.Key == ConsoleKey.Enter)
                {
                    if (entrada.Length > 0)
                        break;
                }
                if ((ConsoleKey.D0 <= cki.Key) && (cki.Key <= ConsoleKey.D9) ||
                    (ConsoleKey.NumPad0 <= cki.Key) && (cki.Key <= ConsoleKey.NumPad9))
                {
                    entrada += cki.KeyChar;
                    Console.Write(cki.KeyChar);
                }
            }
        }
        Console.WriteLine("");
        return entrada;
        }

        public static string lerJuros()
        {
            ConsoleKeyInfo cki;
            string entrada = "";
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Backspace)
                    {
                        if (entrada.Length == 0) continue;
                        entrada = entrada.Remove(entrada.Length - 1);
                        Console.Write("\b \b"); //Remove o último caractere digitado
                    }
                    if (cki.Key == ConsoleKey.Enter)
                    {
                        if (entrada.Length > 0)
                            break;
                    }
                    if (cki.Key == ConsoleKey.OemComma)
                    {
                        entrada += cki.KeyChar;
                        Console.Write(cki.KeyChar);
                    }
                    if ((ConsoleKey.D0 <= cki.Key) && (cki.Key <= ConsoleKey.D9) ||
                     (ConsoleKey.NumPad0 <= cki.Key) && (cki.Key <= ConsoleKey.NumPad9))
                    {
                        entrada += cki.KeyChar;
                        Console.Write(cki.KeyChar);
                       
                    }
                }
            }
            Console.WriteLine("");
            return entrada;
        }

        //=====================================================================================
        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '7')
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       Atendimento        ===");
                    Console.WriteLine("===1 - Cadastrar Veículo     ===");
                    Console.WriteLine("===2 - Listar Veículos       ===");
                    Console.WriteLine("===3 - Remover Veículos      ===");
                    Console.WriteLine("===4 - Ordenar Veículos      ===");
                    Console.WriteLine("===5 - Pesquisar Veículos    ===");
                    Console.WriteLine("===6 - Simular Financiamento ===");
                    Console.WriteLine("===7 - Sair do Sistema       ===");
                    Console.WriteLine("===============================");
                    Console.WriteLine("\n\n");
                    Console.Write("Digite a opção desejada: ");
                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {
                        throw new VeiculosException(excecao.Message);
                    }

                    switch (opcao)
                    {
                        case '1':
                            CadastrarVeiculo();
                            break;
                        case '2':
                            ListarVeiculo();
                            break;
                        case '3':
                            RemoverVeiculo();
                            break;
                        case '4':
                            OrdenarVeiculo();
                            break;
                        case '5':
                            PesquisarVeiculo();
                            break;
                        case '6':
                            SimularFinanciamento();
                            break;
                        case '7':
                            EncerrarAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opcao não implementada.");
                            break;
                    }
                }
            }
            catch (VeiculosException excecao)
            {
                Console.WriteLine($"{excecao.Message}");
            }
        }

        //=====================================================================================
        private void EncerrarAplicacao()
        {
            Console.WriteLine("... Encerrando Programa ...");
            Console.WriteLine("...");
            var caminhoNovoArquivo = @"H:\Meu Drive\Doc Silas\Silas\Logica\Portifolios_Pessoais\Projeto_1_CS\Portifolio_1_StoregeCarSystem\Portifolio_1_StoregeCarSystem\Dat\veiculos.csv";
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                foreach(var veiculo in _Veiculos)
                {
                    var _codigoComInt = veiculo.Codigo.ToString();
                    var _kmComInt = veiculo.KmRodados.ToString();
                    var _anoModeloComInt = veiculo.AnoModelo.ToString();
                    var _anofabComInt = veiculo.AnoFabricacao.ToString();
                    var _valorComint = veiculo.Valor.ToString();
                    escritor.WriteLine(_codigoComInt + ";" + _kmComInt + ";" + _anoModeloComInt + ";" + _anofabComInt + ";" + veiculo.Marca + ";" + veiculo.NovoOuSeminovo + ";" + _valorComint);

                }
                escritor.Close();
                fluxoDeArquivo.Close();
            }

            Console.ReadKey();
        }

        //=====================================================================================
        #region//Simulação
        private void SimularFinanciamento()
        {
            try
            {
                char opcao = '0';
                while (opcao != '2')
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===       SIMULAÇÃO         ===");
                    Console.WriteLine("===                         ===");
                    Console.WriteLine("===    (1) - Simular        ===");
                    Console.WriteLine("===    (2) - Encerrar       ===");
                    Console.WriteLine("===============================");
                    Console.WriteLine("\n");
                    Console.Write("Digite a opção desejada: ");
                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {
                        throw new VeiculosException(excecao.Message);
                    }
                    switch (opcao)
                    {
                        case '1':
                            Simula();
                            break;
                        case '2':
                            Encerra();
                            break;
                           
                    }
                }
            } 
            catch( VeiculosException excecao)
            {
                Console.WriteLine($"{excecao.Message}");
            }
        }

        private void Encerra()
        {
            Console.WriteLine("...Encrrenado Simulação...");
            Console.WriteLine("Retornar ao Menu anterior = ENTER");
            Console.ReadKey();

        }

        private void Simula()
        {
            int _codigo;
            double valorVeiculo;
            do
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       SIMULAÇÃO         ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n");
                Console.WriteLine("Qual o cógio do cadastro para simulação: ");
                _codigo = int.Parse(lerNumeros());
                if (_codigo <= 0)
                {
                    Console.WriteLine("Valor incorreto!");
                }
                VeiculosBase consultaCodigo = ConsultaVeiculosSimulacao(_codigo);
                Console.WriteLine(consultaCodigo.ToString());
                Console.WriteLine("\n");
                valorVeiculo = consultaCodigo.Valor;
                Console.WriteLine($"Valor do veículo: R${valorVeiculo},00\n------------------------------------------------------");
                Console.ReadKey();
            } while (_codigo <= 0);

            double juros;
            do
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       SIMULAÇÃO         ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n");
                Console.WriteLine("Digite a taxa de juros:");
                juros = double.Parse(lerJuros());
                if (juros < 0)
                {
                    Console.WriteLine($"O valor informado é incorreto.");                    
                }
                else if (juros > 3.50)
                {
                    Console.WriteLine($"O valor não pode ser superior à 3.50 a.m.");                    
                }
                else
                {
                    juros = juros / 100;
                    Console.WriteLine($"Taxa de juros de {juros} % ao mês.\n");
                }
            } while (juros < 0 || juros > 3.50);

            int _valorDeEntrada;
            do
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       SIMULAÇÃO         ===");
                Console.WriteLine("===============================");
                Console.WriteLine("\n");
                Console.WriteLine("Valor de entrada: ");
                _valorDeEntrada = int.Parse(lerNumeros());
                if (_valorDeEntrada < 0)
                {
                    Console.WriteLine($"Valor R${_valorDeEntrada},00 incorreto.");
                }
                else
                {
                    Console.WriteLine($"Valor de entrada de R${_valorDeEntrada},00.\n------------------------------------------------------\n");
                }
            } while (_valorDeEntrada < 0);
            int parcelas = 0;
            bool simulabool = false;
            
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       SIMULAÇÃO         ===");
                Console.WriteLine("===============================");
                Console.WriteLine("|   (1) 24x        (2) 36x    |");
                Console.WriteLine("+-----------------------------+");
                Console.WriteLine("|   (3) 48x        (4) 60x    |");
                Console.WriteLine("\\_____________________________/");
                Console.WriteLine("\n");
                Console.WriteLine("Opção de parcelas");
                int op;
                int[] numParcelas = { 24, 36, 48, 60 };
                do {
                    op = int.Parse(Console.ReadLine());
                    if (op <= 0 || op > numParcelas.Length)
                    {
                        Console.WriteLine("valor inválido");
                    }
                    else
                    {
                        
                        parcelas = numParcelas[op-1];
                    }
                } while (op <= 0 || op > numParcelas.Length);
            do
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("===       SIMULAÇÃO         ===");
                Console.WriteLine("===============================");
                Console.WriteLine("=   Valor a ser financiado:   =");
                Console.WriteLine($" R${valorVeiculo - _valorDeEntrada} em {parcelas}x");
                Console.WriteLine("===============================");
                Console.WriteLine("\n");
                double montante = valorVeiculo - _valorDeEntrada;
                montante = montante * Math.Pow((1 + juros), parcelas);
                double jurosTotal = montante - valorVeiculo;
                double parcelasTotal = montante / parcelas;
                Console.WriteLine($"Montante do financiamento {montante.ToString("C")}");
                Console.WriteLine($"Juros sobre o financiamento {jurosTotal.ToString("C")}");
                Console.WriteLine($"Serão {parcelas} parcelas de {parcelasTotal.ToString("C")}");
                Console.WriteLine("Precione qualquer TECLA para voltar");
                Console.ReadKey(simulabool=true);
            } while (simulabool = false);
                                  
        }

        #region //Método Simulacao
        private VeiculosBase ConsultaVeiculosSimulacao(int _codigo)
        {
            return _Veiculos.Where(Codigo => Codigo.Codigo == _codigo).FirstOrDefault();
        }
        #endregion
        #endregion

        //=====================================================================================
        private void PesquisarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   PESQUISAR VEÍCULOS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Deseja pesquisar por (1) Ano de fabricação ou (2) Ano Modelo ou " +
                " (3) Código: ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.Write("Informe o ano de fabricação: ");
                        int anofab = int.Parse(lerNumeros());
                        VeiculosBase consultaVeiculo = ConsultaPorAnoFabricacao(anofab);
                        if(consultaVeiculo != null)
                        {
                            Console.WriteLine(consultaVeiculo.ToString());
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma valor encontrato!");
                            Console.ReadKey();
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("Informe o ano modelo: ");
                        int anomodelo = int.Parse(lerNumeros());
                        VeiculosBase consultaModelo = ConsultaPorAnoModelo(anomodelo);
                        if(consultaModelo != null)
                        {
                            Console.WriteLine(consultaModelo.ToString());
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma valor encontrato!");
                            Console.ReadKey();
                        }
                        break;
                    }
                case 3:
                    {
                        Console.Write("Informe o código do cadastro: ");
                        int _codigo = int.Parse(lerNumeros());
                        VeiculosBase consultaCodigo = ConsultaPorCodigo(_codigo);
                        if(consultaCodigo != null)
                        {
                            Console.WriteLine(consultaCodigo.ToString());
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma valor encontrato!");
                            Console.ReadKey();
                        }
                        break;
                    }
                default:
                    Console.WriteLine("Opcao não implementada.");
                    break;
            }
        }
        #region//Métodos de pesquisas
        private VeiculosBase ConsultaPorCodigo(int? _codigo)
        {
            return _Veiculos.Where(Codigo => Codigo.Codigo == _codigo).FirstOrDefault();
        }
        private VeiculosBase ConsultaPorAnoModelo(int? anomodelo)
        {
            return _Veiculos.Where(anoModelo => anoModelo.AnoModelo == anomodelo).FirstOrDefault();
        }

        private VeiculosBase ConsultaPorAnoFabricacao(int? anofab)
        {
            return _Veiculos.Where(anoFabricacao => anoFabricacao.AnoFabricacao == anofab).FirstOrDefault();
        }
        #endregion

        //=====================================================================================
        
        private void OrdenarVeiculo()
        {
            int escolha;
            string ordena = "";
            string estado = "";
            do
            {
                Console.Clear();
                Console.WriteLine("_______________________");
                Console.WriteLine("|     ORDENA LISTA    |");
                Console.WriteLine("|  (1) -  Código      |");
                Console.WriteLine("|  (2) -  Marca       |");
                Console.WriteLine("|  (3) -  Ano Frab    |");
                Console.WriteLine("|  (4) -  Ano Modelo  |");
                Console.WriteLine("|  (5) -  Preço       |");
                Console.WriteLine("|  (6) -  Condição    |");
                Console.WriteLine("\\---------------------/");
                escolha = int.Parse(lerNumeros());
                if (escolha == 1)
                {
                    var compareCodigo = new ComparaCodigo();
                    _Veiculos.Sort(compareCodigo);
                }
                else if (escolha == 2)
                {
                    var buscaMarca = new VeiculosBase(ordena);
                    var comtemMarca = _Veiculos.Contains(buscaMarca);
                }
                else if (escolha == 3)
                {
                    var compareAno = new ComparaAnoFab();
                    _Veiculos.Sort(compareAno);
                }
                else if (escolha == 4)
                {
                    var compareAnoModelo = new ComparaAnoModelo();
                    _Veiculos.Sort(compareAnoModelo);
                }
                else if (escolha == 5)
                {
                    var comparePreco = new ComparaPreco();
                    _Veiculos.Sort(comparePreco);
                }
                else if (escolha == 6)
                {
                    var buscaCodicao = new VeiculosBase(estado);
                    var comtemCodicao = _Veiculos.Contains(buscaCodicao);
                }
                else
                {
                    Console.WriteLine("Você digitou um valor incorreto.");
                }
                
            } while (escolha <= 0 || escolha > 6);

            
            
            Console.WriteLine("Lista de veículos foi ordenada com sucesso!");
            Console.ReadKey();
        }
        //=====================================================================================
        private void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     REMOVER VEÍCULOS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Informe o código do veíuclo: ");
            int codigo = int.Parse(lerNumeros());
            VeiculosBase veiculo = null;
            foreach (var item in _Veiculos)
            {
                if (item.Codigo == codigo)
                {
                    veiculo = item;
                    break;
                }
            }
            if (veiculo != null)
            {
                _Veiculos.Remove(veiculo);
                Console.WriteLine("Cadastro removido com sucesso!");
            }
            else
            {
                    Console.WriteLine("Cadastro NÂO encontrado");
            }
            Console.ReadKey();

        }
        //=====================================================================================
        private void ListarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    LISTA DE VEÍCULOS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            
            if (_Veiculos.Count <= 0)
            {
                Console.WriteLine("Não há veículos cadastrados");
                Console.ReadKey();
                return;
            }
            foreach (var veiculo in _Veiculos)
            {
                Console.WriteLine(veiculo.ToString());
                Console.WriteLine("----------==========||||||||==========----------");
                Console.ReadKey();
            }
            Console.WriteLine("Press...ENTER...para retornar ao menu anterior.");
            Console.ReadLine();
            

            //var data = File.ReadLines("veiculos.csv");
            //foreach (var line in data)
            //{
            //    VeiculosBase veiculos = line;
            //    Console.WriteLine(veiculos.Codigo);
            //    Console.WriteLine($"Código........: {veiculos.Codigo}");
            //    Console.WriteLine($"Marca.........:{veiculos.Marca}");
            //    Console.WriteLine($"Condição......: {veiculos.NovoOuSeminovo}");
            //    Console.WriteLine($"Kilometrâgem..: {veiculos.KmRodados}");
            //    Console.WriteLine($"Ano do modelo.: {veiculos.AnoModelo}");
            //    Console.WriteLine($"Ano fabricação: {veiculos.AnoFabricacao}");
            //    Console.WriteLine($"Valor.........: R$ {veiculos.Valor},00");
            //    Console.WriteLine("--");
            //}
        }

        //=====================================================================================
        private void CadastrarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===  CADASTRO DE VEÍCULOS   ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados do veiculo===");
            bool codigoRepetido;
            int codigo;
            do
            {
                Console.Write("Código de cadastro: ");
                codigo = int.Parse(lerNumeros());
                codigoRepetido = false;
                foreach (var veiculo in _Veiculos)
                {
                    if (codigo == veiculo.Codigo)
                    {
                        codigoRepetido = true;
                        Console.WriteLine("Esse código pertence a outro cadastro.\n");
                        break;
                    }
                }
            } while (codigoRepetido);
            
            int kilimetragem;
            do 
            {
                Console.Write("Kilimetragem: ");
                kilimetragem = int.Parse(lerNumeros());
                if(kilimetragem < 0)
                {
                    Console.WriteLine("Valor negativo.\n");
                }
            }while (kilimetragem < 0);

            int anofabricacao;
            do
            {
                Console.Write("Ano de fabricação: ");
                anofabricacao = int.Parse(lerNumeros());
                if(anofabricacao <= 1900)
                {
                    Console.WriteLine("valor incorreto.\nDeve ser superior ao ano 1900.\n");
                }
            }while(anofabricacao <= 1900);

            int anomodelo;
            do
            {
                Console.Write("Ano do modelo: ");
                anomodelo = int.Parse(lerNumeros());
                if(anomodelo < anofabricacao || anomodelo > (anofabricacao+1))
                {
                    Console.WriteLine($"O ano modelo não pode ser inferior ao ano de fabricação {anofabricacao}");
                    Console.WriteLine($"Ano modelo não pode ser superior a {anofabricacao+1}");
                }
            } while (anomodelo < anofabricacao || anomodelo > (anofabricacao+1));
            string marca = "";
            int escolha;
            do
            {
                Console.WriteLine("_______________________");
                Console.WriteLine("|  LISTA DE VEÍCULO   |");
                Console.WriteLine("|  (1) -  CHEVROELT   |");
                Console.WriteLine("|  (2) -  HONDA       |");
                Console.WriteLine("|  (3) -  HYUNDAI     |");
                Console.WriteLine("|  (4) -  FIAT        |");
                Console.WriteLine("|  (5) -  CAOA CHERRY |");
                Console.WriteLine("|  (6) -  RENAUL      |");
                Console.WriteLine("|  (7) -  PEGEOUT     |");
                Console.WriteLine("|  (8) -  CRITROEN    |");
                Console.WriteLine("|  (9) -  FORDA       |");
                Console.WriteLine("\\---------------------/");
                
                Console.WriteLine("Qual a marca do veículo:");
                escolha = int.Parse(lerNumeros());
                if (escolha <= 0)
                {
                    Console.WriteLine("valor inválido");
                }
                else if (escolha > 10)
                {
                    Console.WriteLine("valor inválido");
                }
                else
                {
                    string[] carrosMarca = { "CHEVROELT", "HONDA", "HYUNDAI", "FIAT", "CAOA CHERRY", "RENAUL", "PEGEOUT", "CRITROEN", "FORDA" };
                    marca = carrosMarca[escolha-1];
                    
                }
            } while (escolha <= 0 || escolha > 10);

            string condicao;
            do
            {
                Console.WriteLine("_______________________");
                Console.WriteLine("| SITUAÇÃO DO VEÍCULO |");
                Console.WriteLine("|  (1) -  NOVO        |");
                Console.WriteLine("|  (2) -  SEMINOVO    |");
                Console.WriteLine("\\---------------------/");
                condicao = Console.ReadLine();
                if (condicao == "1")
                {
                    Console.WriteLine("Opção salva com sucesso");
                    condicao = "Novo";
                    break;
                }
                else if (condicao == "2")
                {
                    Console.WriteLine("Opção salva com sucesso");
                    condicao = "Seminovo";
                    break;
                }
                else
                {
                    Console.WriteLine("Você digitou um valor incorreto");
                }
            } while (condicao == "1" || condicao == "2");
            int valor;
            do
            {
                Console.WriteLine("Digite o valor do veículo:");
                valor = int.Parse(lerNumeros());
                if(valor < 0)
                {
                    Console.WriteLine($"Dado inválido, você digitou R$ {valor} e não é um valor válido.");
                }
                else
                {
                    Console.WriteLine("Valor adicionado com sucesso!");
                }
            }while (valor < 0);

            _Veiculos.Add(new VeiculosBase(codigo, kilimetragem, anomodelo, anofabricacao, marca, condicao, valor));

            Console.ReadKey();
        }
    }
}
