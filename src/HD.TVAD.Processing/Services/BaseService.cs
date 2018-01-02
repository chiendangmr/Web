using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HD.TVAD.Web.Services
{
	public class Service<TEntity, TRepository> : IService<TEntity> where TEntity : class  where TRepository : IRepository<TEntity>
	{
		protected TRepository _repository;
		public Service(TRepository repository)
		{
			_repository = repository;
		}
		public Task<int> Create(TEntity entity)
		{
			return _repository.Create(entity);
		}

		public Task<int> Delete(TEntity entity)
		{
			return _repository.Delete(entity);
		}

		public IQueryable<TEntity> GetAll()
		{
			return _repository.List();
		}

		public IQueryable<TEntity> Get(Guid id)
		{
			return _repository.Get(id);
		}        
        public Task<int> Update(TEntity entity)
		{
			return _repository.Update(entity);
		}

		public Task<int> DeleteRange(ICollection<TEntity> entities)
		{
			return _repository.DeleteRange(entities);
		}
		public Task<int> UpdateRange(ICollection<TEntity> entities)
		{
			return _repository.UpdateRange(entities);
		}

		public Task<int> DeleteThenUpdateRange(ICollection<TEntity> oldEntities, ICollection<TEntity> newEntities)
		{
			return _repository.DeleteThenUpdateRange(oldEntities, newEntities);
		}
	}
}
