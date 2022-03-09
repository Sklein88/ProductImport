using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{

    public class SoftwareAdviceProduct : IProduct
    {
        #region Properties
        
        public List<SoftwareAdviceProduct> products { get ; set; } = new List<SoftwareAdviceProduct>();
        public int Id { get; set; }
        public string title { get; set; } = string.Empty;
        public string twitter { get; set; } = string.Empty;
        public IClient Client { get; set; }
        public IList<string> categories { get; set; } = new List<string>();
        public string name { get; set; } = string.Empty;

        #endregion

        #region constructors
        
        public SoftwareAdviceProduct() { }

        public SoftwareAdviceProduct(IClient softwareAdvice)
        {
            Client = softwareAdvice;
        }

        #endregion

        #region overrides

        public override string ToString()
        {
            var categories = String.Join(", ", this.categories.ToArray());

            return $"title: {this.title}; {(String.IsNullOrWhiteSpace(this.twitter) ? String.Empty : $"twitter: {this.twitter};")} Categories: {categories};";
        }

        #endregion
    }
}
