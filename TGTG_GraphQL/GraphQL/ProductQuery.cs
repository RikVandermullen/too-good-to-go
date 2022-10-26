namespace TGTG_GraphQL.GraphQL
{
    [ExtendObjectType("Query")]
    public class ProductQuery
    {
        private readonly IProductRepository _productRepository;

        public ProductQuery(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> Products()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProductById(id);
        }
    }
}
