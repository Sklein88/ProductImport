using Application.Interfaces;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ProductRepository : IProductRepositoryU
    {
        public Task<bool> CreateProducts(IClient client, IList<IProduct> product)
        {
            return Task.FromResult(true);
        }
    }
}
