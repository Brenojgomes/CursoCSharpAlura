using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
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
