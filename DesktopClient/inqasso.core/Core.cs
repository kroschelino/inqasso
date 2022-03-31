using Inqasso.Core.Interfaces;
using Inqasso.Core.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Inqasso.Core
{
    public class Core 
    {
        private const string DatabaseName = "inqasso";
        private const string DataSource = "";

        private readonly ILogger<Core> _logger;

        public Core(ILogger<Core>? logger = null)
        {
            _logger = logger ?? NullLogger<Core>.Instance;
        }

        public virtual IEnumerable<IProduct> GetProducts()
        {
            using var context = CreateContext();
            var products = new List<IProduct>();
            foreach (var product in context.Products.ToList())
            {
                yield return new Product(this, product.Id);
            }
        }

        internal InqassoContext CreateContext()
        {
            return new InqassoContext();
        }

    }
}