namespace TGTG_EF
{
    public class ProductEFRepository : IProductRepository
    {
        private readonly TGTGDbContext _dbContext;

        public ProductEFRepository(TGTGDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product? AddProduct(Product newProduct)
        {
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();

            return newProduct;
        }

        public Product? DeleteProduct(Product product)
        {
            var entityToRemove = _dbContext.Products.FirstOrDefault(r => r.Name == product.Name);
            if (entityToRemove != null)
            {
                _dbContext.Products.Remove(entityToRemove);
                _dbContext.SaveChanges();
            }

            return entityToRemove;
        }

        public Product? GetProductByName(string name)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Name.Equals(name));
        }

        public Product? GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product>? GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product? UpdateProduct(Product product)
        {
            var entityToUpdate = _dbContext.Products.FirstOrDefault(r => r.Name == product.Name);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = product.Name;
                entityToUpdate.HasAlcohol = product.HasAlcohol;
                entityToUpdate.Image = product.Image;

                _dbContext.SaveChanges();
            }

            return entityToUpdate;
        }
    }
}
