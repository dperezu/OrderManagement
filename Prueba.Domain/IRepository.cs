using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Domain
{
    public interface IRepository
    {
        string Get();
        void Save(string data);
    }
}
