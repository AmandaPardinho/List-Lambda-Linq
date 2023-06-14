using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankList.Extensoes
{
    public static class ListExtensoes
    {
        /* método de extensão =>
         * para gerar um método de extensão é preciso criar um método estático em uma classe estática e definir como primeiro argumento o tipo que queremos extender 
         * para sinalizar que é um método de extensão usa-se a palavra reservada 'this' do primeiro argumento
         * métodos de extensão não podem ser criados em classes genéricas
         * ** para definir um método de extensão genérico, é preciso adicionar o <T> na frente do nome do método => isso criará um método genérico em uma classe estática não genérica
         */
        public static void AdicionarVarios<T>(this List<T> listaInteiros, params T[] itens)
        {
            foreach (T item in itens)
            {
                listaInteiros.Add(item);
            }
        }
    }
}