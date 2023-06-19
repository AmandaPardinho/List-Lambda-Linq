using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ByteBankList.SistemaAgencia;
using ByteBankList.Modelos.Conta;
using ByteBankList.Extensoes;
using ByteBankList.Modelos.Util;
using ByteBankList.Comparadores;

namespace ByteBankList
{
    public class Program
    {
        static void Main(string[] args)
        { 
            var contas = new List<ContaCorrente>() 
            { 
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 1),
                null,
                null,
                new ContaCorrente(340, 99999),
                new ContaCorrente(340, 48950),
                null,
                new ContaCorrente(290, 18950)
            };

            //contas.Sort(); => Chama a implementação dada em IComparable

            //contas.Sort(new ComparadorContaCorrenteAgencia());

            /*var listaSemNulos = new List<ContaCorrente>();
            foreach (var conta in contas) 
            {
                if(conta != null)
                {
                    listaSemNulos.Add(conta);
                } 
            }

            var contasNaoNulas = contas.Where(conta => conta != null);*/

            var contasOrdenada = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenada)
            {
                Console.WriteLine($"Número da conta: {conta.Numero}\nAgência: {conta.Agencia}");
                
            }

            Console.ReadKey();
        }

        static void TestaSort()
        {
            var nomes = new List<string>()
            {
                "Fábio",
                "Ana",
                "Julio",
                "Rafael",
                "Juliana"
            };

            nomes.Add("Guilherme");
            nomes.Add("Amanda");
            nomes.AdicionarVarios("Luana", "Wellington", "Pedro");

            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }
            Console.WriteLine();

            var idades = new List<int>();

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            //o método pode ser chamado assim
            ListExtensoes.AdicionarVarios(idades, 56, 26, 17, 98);

            //ou assim (tem o argumento que referencia a lista implícito)
            idades.AdicionarVarios(6, 2, 11, 87, 99);

            //idades.Remove(5);

            //método para ordenar o conteúdo da lista
            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                int idadeAtual = idades[i];
                Console.WriteLine(idadeAtual);
            }
        }

        static void TestaListaObject()
        {
            ListaObject listaIdades = new ListaObject();

            listaIdades.Adicionar(10);
            listaIdades.Adicionar(5);
            listaIdades.Adicionar(4);
            listaIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaIdades.Tamanho; i++)
            {
                int idade = (int)listaIdades[i];
                Console.WriteLine($"Idade no índice {i}: {idade} anos");
            }
        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

        static void TestaListaDeConta()
        {
            ListaContaCorrente lista = new ListaContaCorrente();

            lista.Adicionar(new ContaCorrente(874, 5679787));
            lista.Adicionar(new ContaCorrente(874, 4456668));
            lista.Adicionar(new ContaCorrente(874, 7781438));
            lista.Adicionar(new ContaCorrente(874, 3379781));
            lista.Adicionar(new ContaCorrente(874, 1056228));
            lista.Adicionar(new ContaCorrente(874, 8881432));
            lista.Adicionar(new ContaCorrente(874, 5679755));
            lista.Adicionar(new ContaCorrente(874, 3156298));
            lista.Adicionar(new ContaCorrente(874, 7481266));

            ContaCorrente conta = new ContaCorrente(023, 0000001);
            lista.Adicionar(conta);
            Console.WriteLine("Conta 'conta' foi adicionada");
            Console.WriteLine();
            lista.EscreverListaNaTela();
            Console.WriteLine();
            lista.Remover(conta);
            Console.WriteLine("Conta 'conta' foi removida");
            Console.WriteLine();
            lista.EscreverListaNaTela();
            Console.WriteLine();

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente novoItem = lista.GetItemNoIndice(i);
                Console.WriteLine($"Item na posição {i} = Conta {novoItem.Numero}/{novoItem.Agencia}\n");
            }

            ContaCorrente[] contasParaAdicionar = new ContaCorrente[]
            {
                new ContaCorrente(874, 7781438),
                new ContaCorrente(874, 3379781),
                new ContaCorrente(874, 1056228),
                new ContaCorrente(874, 8881432),
                new ContaCorrente(874, 5679755),
                new ContaCorrente(874, 3156298),
                new ContaCorrente(874, 7481266)
            };

            lista.AdicionarVarios(contasParaAdicionar);
            lista.AdicionarVarios(
                new ContaCorrente(874, 7781438),
                new ContaCorrente(874, 3379781),
                new ContaCorrente(874, 1056228),
                new ContaCorrente(874, 8881432),
                new ContaCorrente(874, 5679755),
                new ContaCorrente(874, 3156298),
                new ContaCorrente(874, 7481266)
                );
        }

        static void TestaArrayContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 4456668),
                new ContaCorrente(874, 7781438)
            };

            for (int i = 0; i < contas.Length; i++)
            {
                ContaCorrente contaAtual = contas[i];
                Console.WriteLine($"Conta {i} {contaAtual.Numero}");
            }

            Console.ReadKey();
        }

        static void ExemploVar()
        {
            /* var => (inferência de tipo de variável)
           * palavra reservada do .Net
           * faz com que o compilador assuma que seu valor será igual ao do tipo que foi atribuído à variável criada
           * não é possível usar o 'var' quando não inicializamos/atribuímos a variável
           */

            var conta = new ContaCorrente(347, 147852369);
            var gerenciador = new GerenciadorBonificacao();
            var gerenciadores = new List<GerenciadorBonificacao>();
        }
    }
}
