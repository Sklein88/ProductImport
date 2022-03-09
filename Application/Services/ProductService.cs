using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        IProductRepositoryU _productRepository;

        public ProductService(IProductRepositoryU productRepositoryU)
        {
            _productRepository = productRepositoryU;
        }

        public async Task<bool> CreateProducts(IClient client, List<IProduct> products)
        {
            try
            { 
                return await _productRepository.CreateProducts(client, products);
            }
            catch(Exception ex)
            {
                return await Task.FromException<bool>(ex);
            }
        }
    }
}
