using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNlayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private  AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
           return await _appDbContext.Products.Include(I => I.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}
