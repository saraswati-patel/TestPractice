using TestPractice.Models;

namespace TestPractice.Data.Repositories
{
    public interface IProduct
    {
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        //Task<Product> GetEmployee(int employeeId);
        Task<Product> AddProducts(Product product);
        Task<Product> UpdateProductDetails(int id,Product product);
        void DeleteByProductId(int Id);
    }
}
