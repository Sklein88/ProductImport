using Application.Models;
using Application.Repositories;
using Application.Services;

string filename = Environment.GetCommandLineArgs()[2];
string ext = Path.GetExtension(filename);
string clientName = filename.Substring(0, filename.Length - ext.Length);
string clientNameByParam = Environment.GetCommandLineArgs()[1];

try
{
	using (var reader = new StreamReader(filename))
	{
		var repository = new ProductRepository();
		ProductService _productService = new ProductService(repository);
		ClientService _clientService = new ClientService();

		var client = await _clientService.GetClientByName(clientNameByParam);

		var items = client.Deserealize(reader);

		await _productService.CreateProducts(client, items.ToList<IProduct>());

		foreach (var item in items)
		{
			Console.WriteLine(item.ToString());
		}
	}
} 
catch (Exception ex)
{
	Console.Write(ex.ToString());
}