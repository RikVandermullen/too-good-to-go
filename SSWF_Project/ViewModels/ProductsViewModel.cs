using Domain;

namespace TGTG_Portal.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
    }
}
