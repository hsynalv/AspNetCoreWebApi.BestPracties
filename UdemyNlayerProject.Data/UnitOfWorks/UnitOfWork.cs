using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNlayerProject.Data.Repositories;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.UnitOfWorks;

namespace UdemyNlayerProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_appDbContext);

        public ICategoryRepository Category => _categoryRepository = _categoryRepository ?? new CategoryRepository(_appDbContext);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CommitChanges()
        {
           _appDbContext.SaveChanges();
        }

        public async Task CommitChangesAsync()
        {
           await _appDbContext.SaveChangesAsync();
        }
    }
}
