using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Client;
using Application.Interfaces;
using Application.Models;
using Application.Repositories;
using Application.Services;

namespace ProductImport
{
    public class ConsoleApplication
    {

		private readonly IProductService _productService;
		private readonly IProductRepositoryU _productRepository;

		private readonly IClientService _clientService;

		public ConsoleApplication(IProductService productService,
			IProductRepositoryU productRepository,
			IClientService clientService)
		{
			_productService = productService;
			_productRepository = productRepository;
			_clientService = clientService;
		}

		public async void Run()
		{
			string filename = Environment.GetCommandLineArgs()[2];
			string ext = Path.GetExtension(filename);
			string clientName = filename.Substring(0, filename.Length - ext.Length);
			string clientNameByParam = Environment.GetCommandLineArgs()[1];

			try
			{
				using (var reader = new StreamReader(filename))
				{


					//call the client service asking for the client
					var client = await _clientService.GetClientByName(clientNameByParam);

					var items = client.Deserialize(reader);

					await _productService.CreateProducts(client, items.ToList<IProduct>());

					foreach (var item in items)
					{
						//each item writes his own output
						Console.WriteLine(item.ToString());
					}
				}
			}
			catch(Exception ex)
            {
				Console.WriteLine($"{ex.Message} {ex.InnerException} {ex.Source}");
            }
		}
	}
}
