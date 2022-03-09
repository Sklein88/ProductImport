using Application.Interfaces;
using Application.Models;
using Application.Repositories;
using Application.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;


namespace GartnerCommandLine.ProductServiceTest
{
    public class ProductServiceTest
    {
        #region setup

        private readonly IServiceProvider _provider;

        private readonly Mock<IProductService> _mockProductService = new Mock<IProductService>();
        private IProductService _productService;
        private IProductRepositoryU _productRepositoryU;


        public class NotCapterra : IClient
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public List<IProduct> Deserialize(StreamReader reader)
            {
                throw new NotImplementedException();
            }
        }

        private void Setup()
        {
            _productRepositoryU = new ProductRepository();
            _productService = new ProductService(_productRepositoryU);
        }

        public ProductServiceTest() => this.Setup();

        #endregion

        [Fact]
        public async Task CreateProducts_Returns_True()
        {
            var client = new Capterra();
            var mockProductList = new Mock<List<IProduct>>();
            var mockProductRepository = new Mock<IProductRepositoryU>();
            _productService = new ProductService(mockProductRepository.Object);

            mockProductRepository.Setup(foo => foo.CreateProducts(It.IsAny<IClient>(), It.IsAny<List<IProduct>>())).ReturnsAsync(true);
            _mockProductService.Setup(foo => foo.CreateProducts(It.IsAny<IClient>(), It.IsAny<List<IProduct>>())).ReturnsAsync(true);

            Assert.True(await _productService.CreateProducts(client, mockProductList.Object));
        }

        [Fact]
        public async Task CreateProducts_Returns_False()
        {
            var client = new Capterra();
            var mockProductList = new Mock<List<IProduct>>();
            var mockProductRepository = new Mock<IProductRepositoryU>();
            _productService = new ProductService(mockProductRepository.Object);

            _mockProductService.Setup(foo => foo.CreateProducts(It.IsAny<IClient>(), It.IsAny<List<IProduct>>())).ReturnsAsync(false);

            var result = await _productService.CreateProducts(client, mockProductList.Object);

            Assert.False(result);
        }

        [Fact]
        public async Task CreateProducts_Should_ReturnFalse()
        {
            var client = new Capterra();

            var mockProductList = new Mock<List<IProduct>>();
            var mockProductRepository = new Mock<IProductRepositoryU>();
            _productService = new ProductService(mockProductRepository.Object);

            _mockProductService.Setup(foo => foo.CreateProducts(It.IsAny<IClient>(), It.IsAny<List<IProduct>>())).ReturnsAsync(false);

            var result = await _productService.CreateProducts(client, mockProductList.Object);

            Assert.False(result);
        }

        [Theory]
        [InlineData("GitGHub", "github", "Instant Messaging & Chat,Web Collaboration,Productivity")]
        [InlineData("Slack", "slackhq", "Bugs & Issue Tracking,Development Tools")]
        [InlineData("JIRA Software", "jira", "Project Management,Project Collaboration,Development Tools")]
        public async Task Process_File_Capterra(string name, string twitter, string tags)
        {
            var client = new Capterra();
            var capterraProduct = new CapterraProduct(client)
            {
                Client = client,
                name = name,
                twitter = twitter,
                tags = tags,
            };

            var productList = new List<IProduct>();
            var mockProductRepository = new Mock<IProductRepositoryU>();

            productList.Add(capterraProduct);
            _productService = new ProductService(mockProductRepository.Object);

            mockProductRepository.Setup(foo => foo.CreateProducts(It.IsAny<IClient>(), It.IsAny<List<IProduct>>())).ReturnsAsync(true);

            var result = await _productService.CreateProducts(client, productList);

            Assert.True(result);
        }
    }
}