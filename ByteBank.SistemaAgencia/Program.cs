using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Text.RegularExpressions;
using ByteBank.SistemaAgencia.Extensoes;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> idades = new List<int>();

            idades.Add(0);
            idades.Add(5);
            idades.Add(8);
            idades.Add(15);
            idades.Add(30);
            
            idades.Remove(5);

            idades.AdicionarVarios(80, 75, 25);

            foreach(int i in idades)
            {
                Console.WriteLine(i);
            }



            //Lista<int> idades = new Lista<int>();

            //idades.Adicionar(5);
            //idades.AdicionarVarios(1, 5, 78);

            //Console.WriteLine(SomarVarios(1, 2, 3, 5, 56465, 45));
            //Console.WriteLine(SomarVarios(1, 2, 45));

            Console.ReadLine();
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            listaDeIdades.Adicionar("um texto qualquer");
            listaDeIdades.AdicionarVarios(16, 23, 60);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no indice {i}: {idade}");
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


        static void TestaListaDeContaCorrente()
        {
            //ListaDeContaCorrente lista = new ListaDeContaCorrente();
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoGui = new ContaCorrente(11111, 1111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679754)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDoGui,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }


        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(874, 464846),
                new ContaCorrente(874, 574852),
                new ContaCorrente(874, 658521)
            };

            for (int indice = 0; indice < contas.Length; indice++)
            {

                ContaCorrente contaAtual = contas[indice];
                Console.WriteLine($"Conta {indice} {contaAtual.Numero}");

            }


            Console.ReadLine();
        }

        static void testaArrayInt()
        {
            
            //Array de inteiros com 5 posições
            int[] idades = new int[6];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            idades[3] = 50;
            idades[4] = 28;
            idades[5] = 30;

            int acumulador = 0;
            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no índice {indice}");
                Console.WriteLine($"Valor de idades [{indice}] = {idade}");

                acumulador += idade;
                Console.WriteLine($"Somatória de idades: {acumulador}\n");
            }

            int mediaDeIdades = acumulador / idades.Length;
            Console.WriteLine($"A média de idades é: {mediaDeIdades}");

            Console.ReadLine();
        }

        static void TestaString()
        {

            // Regex.IsMatch --> verifica se existe um padrão determinado na string selecionada.
            // Regex.Match --> acha o padrão em uma string e salva.
            // "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            // "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            // "[0-9]{4}[-][0-9]{4}";
            // "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            // "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";


            string textoDeTexte = "Meu nome é Guilherme, me ligue em 4784-4546.";

            bool verificacaoNumero = Regex.IsMatch(textoDeTexte, padrao);
            Match resultado = Regex.Match(textoDeTexte, padrao);

            Console.WriteLine("O texto possui um número de telefone? " + verificacaoNumero);
            Console.WriteLine("O Numero de telefone é : " + resultado);

            Console.ReadLine();


            // .StartsWith | .EndsWith | .Contains
            string urlTeste = "https://www.bytebank.com/cambio";
            int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");

            bool verificacao = urlTeste.StartsWith("https://www.bytebank.com");
            Console.WriteLine(urlTeste.EndsWith("cambio/"));
            Console.WriteLine(urlTeste.Contains("bytebank"));

            Console.WriteLine("É o site oficial do ByteBank: " + verificacaoNumero);

            Console.WriteLine(indiceByteBank == 0);

            Console.ReadLine();


            // ToUpper -> tudo em maiusculo  | ToLower -> tudo em minusculo
            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            ExtratorValorDeArgumentosURL extrator = new ExtratorValorDeArgumentosURL(urlParametros);

            string valor = extrator.GetValor("moedaDestino");
            Console.WriteLine("Valor de moedaDestino: " + valor);

            string valorMoedaOrigem = extrator.GetValor("moedaOrigem");
            Console.WriteLine("Valor de moedaOrigem: " + valorMoedaOrigem);

            Console.WriteLine(extrator.GetValor("VALOR"));
            Console.ReadLine();

            string palavra = "moedaOrigem=moedaDestino&moedaDestino=dolar";
            string nomeArgumento = "moedaDestino=";
            int indice = palavra.IndexOf(nomeArgumento);
            Console.WriteLine(indice);
            Console.WriteLine("Tamanho da string nomeArgumento: " + nomeArgumento.Length);

            Console.WriteLine(palavra);
            Console.WriteLine(palavra.Substring(indice));
            Console.WriteLine(palavra.Substring(indice + nomeArgumento.Length));
            Console.ReadLine();



            //Testando o IsNullOrEmpty
            string textoVazio = "";
            string textoNulo = null;
            string textoQualquer = "BrenoGomes";
            Console.WriteLine(string.IsNullOrEmpty(textoVazio));
            Console.WriteLine(string.IsNullOrEmpty(textoNulo));
            Console.WriteLine(string.IsNullOrEmpty(textoQualquer));
            Console.ReadLine();

            //DateTime-- > manipulação de tempo(datas, meses, semanas, dias, horas, minutos...)
            DateTime dataFimPagamento = new DateTime(2022, 8, 17);
            DateTime dataCorrente = DateTime.Now;

            TimeSpan diferenca = dataFimPagamento - dataCorrente;

            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            Console.WriteLine(dataCorrente);
            Console.WriteLine(dataFimPagamento);
            Console.WriteLine("Vencimento em: " + mensagem);

            Console.ReadLine();
        }

    }
}
