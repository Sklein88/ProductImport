using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CapterraProduct : IProduct
    {
        public string tags { get; set; } = string.Empty;
        public string twitter { get; set; } = string.Empty;
        public int Id { get; set; }
        public IClient Client { get; set; }
        public string name { get; set; } = string.Empty;
        public CapterraProduct() { }
        public CapterraProduct(IClient capterra)
        {
            Client = capterra;
        }

        public override string ToString()
        {
            return $"name: {this.name}; Categories: {this.tags}; twitter: {this.twitter}";
        }
    }
}
