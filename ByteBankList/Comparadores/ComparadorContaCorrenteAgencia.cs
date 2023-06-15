using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBankList.Modelos.Conta;

namespace ByteBankList.Comparadores
{
    public class ComparadorContaCorrenteAgencia : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente? x, ContaCorrente? y)
        {
            if(x == y)
            {
                return 0;
            }

            if(x == null)
            {
                return 1;
            } 
            else if(y == null)
            {
                return -1;
            }

            return x.Agencia.CompareTo(y.Agencia);


            // O código comentado abaixo é equivalente ao implementado pela interface IComparable na classe ContaCorrente e, por isso, pode ser substituído pelo código da linha 28

            /*if (x.Agencia < y.Agencia)
            {
                return -1; //x fica na frente de y
            }
            else if(x.Agencia == y.Agencia)
            {
                return 0; //são equivalentes
            }
            else
            {
                return 1; //y fica na frente de x
            }*/
        }
    }
}
