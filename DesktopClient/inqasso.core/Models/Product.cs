namespace Inqasso.Core.Models
{
    internal class Product
    {
        public Product()
        {
            TypicalSizes = new List<int>();
        }

        public int Id { get; set; }
        public string? Producer { get; set; }
        public string? Name { get; set; }
        public string? Flavor { get; set; }
        public IEnumerable<int> TypicalSizes { get; set; }
    }
}
