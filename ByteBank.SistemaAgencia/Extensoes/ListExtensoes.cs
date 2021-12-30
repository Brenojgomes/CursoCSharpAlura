using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            foreach(T item in itens)
            {
                lista.Add(item);    
            }

        }

        static void Teste()
        {
            List<int> idades = new List<int>();
            idades.Add(7);
            idades.Add(5);
            idades.Add(26);

            idades.AdicionarVarios<int>(5, 60, 28);

            List<string> nomes = new List<string>();
            nomes.Add("breno");
            nomes.Add("bruno");
            nomes.Add("bruce");

            nomes.AdicionarVarios("Carlos", "Rubens");
        }


    }
}
