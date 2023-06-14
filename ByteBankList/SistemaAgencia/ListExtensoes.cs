using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankList.SistemaAgencia
{
    public static class ListExtensoes
    {
        /* método de extensão =>
         * para gerar um método de extensão é preciso criar um método estático em uma classe estática e definir como primeiro argumento o tipo que queremos extender 
         * para sinalizar que é um método de extensão usa-se a palavra reservada 'this' do primeiro argumento
         */
        public static void AdicionarVarios(this List<int> listaInteiros, params int[] itens)
        {
            foreach (int item in itens)
            {
                listaInteiros.Add(item);
            }
        }
    }
}