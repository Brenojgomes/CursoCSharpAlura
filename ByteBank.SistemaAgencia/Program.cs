using ByteBank.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;


namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {


            string palavra = "moedaOrigem=real&moedaDestino=dolar";
            string nomeArgumento = "moedaDestino";
            int indice = palavra.IndexOf(nomeArgumento);
            Console.WriteLine(indice);
            Console.WriteLine("Tamanho da string nomeArgumento: " + nomeArgumento.Length);

            Console.WriteLine(palavra);
            Console.WriteLine(palavra.Substring(indice));
            Console.WriteLine(palavra.Substring(indice + nomeArgumento.Length + 1));




            //Testando o IsNullOrEmpty
            //string textoVazio = "";
            //string textoNulo = null;
            //string textoQualquer = "BrenoGomes";
            //Console.WriteLine(string.IsNullOrEmpty(textoVazio));
            //Console.WriteLine(string.IsNullOrEmpty(textoNulo));
            //Console.WriteLine(string.IsNullOrEmpty(textoQualquer));
            
            
            // DateTime --> manipulação de tempo (datas,meses,semanas,dias,horas,minutos...)
            //DateTime dataFimPagamento = new DateTime(2022,8,17);
            //DateTime dataCorrente = DateTime.Now;

            //TimeSpan diferenca = dataFimPagamento - dataCorrente;

            //string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);

            //Console.WriteLine(dataCorrente);  
            //Console.WriteLine(dataFimPagamento);
            //Console.WriteLine("Vencimento em: " + mensagem);
            
            Console.ReadLine(); 

        }

    }
}
