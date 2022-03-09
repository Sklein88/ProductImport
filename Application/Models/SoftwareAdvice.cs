using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SoftwareAdvice : IClient
    {
        public int Id { get; set; }
        public string Name { get { return "SoftwareAdvice"; } }

        public List<IProduct> Deserealize(StreamReader reader)
        {
            string json = reader.ReadToEnd();
            SoftwareAdviceProduct softwareAdviceProduct =
                           JsonSerializer.Deserialize<SoftwareAdviceProduct>(json)!;

            return softwareAdviceProduct.products.ToList<IProduct>();
        }
    }
}
