﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain
{
    public class DomainService
    {
        public string Process(Entity entity)
        {
            return $"Processed: {entity.GetData()}";
        }
    }
}

