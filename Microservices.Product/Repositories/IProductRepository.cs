using Microservice.Product.Models;
namespace Microservices.Product.Repositories
{
    public interface IProductRepository
    {
        void AddProduct(ProductModel product);
        void DeleteProduct(int id);
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel? GetProductById(int id);
        void UpdateProduct(ProductModel product);
    }
}