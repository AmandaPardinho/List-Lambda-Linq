using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankList.Modelos.Util
{
    public interface IAutenticavel
    {
        bool Autenticar(string senha);
    }
}
