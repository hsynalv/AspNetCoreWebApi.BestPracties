using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWorks;

namespace UdemyNlayerProject.Service.Services
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;

        public BaseService(IUnitOfWork unitOfWork,IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitChangesAsync();
            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.CommitChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
           _repository.RemoveRange(entities);
            _unitOfWork.CommitChanges();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.SingleOrDefaultAsync(filter);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity entityType = _repository.Update(entity);
            _unitOfWork.CommitChanges();
            return entityType;

        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.Where(filter);
        }
    }
}
