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
        /// <summary>
        /// Returns the reader file as a IProduct implementation
        /// </summary>
        /// <param name="reader"> the file </param>
        /// <returns> List<IProduct> </returns>
        public abstract List<IProduct> Deserialize(StreamReader reader);

    }
}
