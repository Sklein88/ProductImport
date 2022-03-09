using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GartnerCommandLine.Database.Interfaces
{
    public class ProductRepository : IProductRepositoryU
    {
        public Task<bool> CreateProduct(IList<IProduct> product)
        {
            return Task.FromResult(true);
        }
    }
}
