using Microsoft.EntityFrameworkCore;
using TestPractice.Models;
using TestPractice.Models.Dto;

namespace TestPractice.Data.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly BirlaDBContext _dbContext;
        public ProductRepository(BirlaDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<Product> AddProducts(Product product)
        {
            var result = await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteByProductId(int id)
        {
            var product = await _dbContext.Products.FirstAsync(p => p.Id == id);
            if (product != null)
            {
                _dbContext.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateProductDetails(int id, Product product)
        {
            var result=   await _dbContext.Products.FirstAsync(p => p.Id == id);
            if (result != null)
            {
                result.Quantity = product.Quantity;
                result.Description = product.Description;
                result.Price = product.Price;
                result.Name = product.Name;
                result.Category = product.Category;
            
             await _dbContext.SaveChangesAsync();
            }
            return result;


        }

        public async Task<Product> GetProductById(int id)
        {
          return  await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

       
    }
}
