using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IProduct 
    {
        public int Id { get; set; }
        public string name { get; set; }
        public IClient Client { get; set; }
        public abstract string ToString();
    }
}
