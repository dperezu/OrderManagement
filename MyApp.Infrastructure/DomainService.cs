using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prueba.Domain;

namespace MyApp.Infrastructure;

public class DomainService : IDomainService
{
    public string Process(Entity entity)
    {
        return $"Processed: {entity.GetData()}";
    }
}

