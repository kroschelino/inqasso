using Inqasso.Core;
using Inqasso.Import.Interfaces;

namespace Inqasso.Import
{
    internal class ImportApplication : IImportService
    {
        private readonly Core.Core _inqassoCore; 
        public ImportApplication(Core.Core inqassoCore)
        {
            _inqassoCore = inqassoCore;
        }

        public void DisplayProducts()
        {
            foreach (var product in _inqassoCore.GetProducts())
            {
                Console.WriteLine($"Product: {product.Name} ({product.Flavor}); Typical sizes are {String.Join(",", product.TypicalSizes)}");
            }
        }
    }


}


