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
	public class ServiceForIntId<TEntity, TRepository> : IServiceForIntId<TEntity> where TEntity : class  where TRepository : IRepositoryForIntId<TEntity>
	{
		private TRepository _repository;
		public ServiceForIntId(TRepository repository)
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

		public IQueryable<TEntity> Get(int id)
		{
			return _repository.Get(id);
		}

		public Task<int> Update(TEntity entity)
		{
			return _repository.Update(entity);
		}        
    }
}
