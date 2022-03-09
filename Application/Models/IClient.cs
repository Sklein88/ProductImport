using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IClient
    {
        public int Id { get; set; } 
        public string Name { get; }
        public abstract List<IProduct> Deserealize(StreamReader reader);

    }
}
