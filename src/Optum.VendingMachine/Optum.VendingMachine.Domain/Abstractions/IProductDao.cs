using System;
using System.Collections.Generic;
using System.Text;

namespace Optum.VendingMachine.Domain
{
    public interface IProductDao
    {
        IReadOnlyList<Product> GetProducts();
    }
}
