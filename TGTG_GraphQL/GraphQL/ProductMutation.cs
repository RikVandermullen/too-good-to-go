namespace TGTG_GraphQL.GraphQL
{
    [ExtendObjectType("Mutation")]
    public class ProductMutation
    {
        private readonly IProductRepository _productRepository;

        public ProductMutation(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(NewProductDTO product) => _productRepository.AddProduct(new Product { Name = product.Name, Image = product.Image, HasAlcohol = product.HasAlcohol });
        
        public Product UpdateProduct(NewProductDTO2 product) => _productRepository.UpdateProduct(new Product { Id = product.Id, Name = product.Name, Image = product.Image, HasAlcohol = product.HasAlcohol });

        public bool DeleteProduct(int id)
        {
            var Product = _productRepository.GetProductById(id);

            if (Product != null)
            {
                _productRepository.DeleteProduct(Product);
                return true;
            }
            return false;
        }
    }
}
