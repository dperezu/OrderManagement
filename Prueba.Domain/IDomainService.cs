using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain
{
    public interface IDomainService
    {
        string Process(Entity entity);
    }
}
