using System;
using System.Collections.Generic;
using Entities.Interfaces;

namespace DataContext.Interfaces
{
	public interface IRepozitory<T>where T:IEntities
	{
		public bool Create(T entity);
		public bool Delate(T entity);
		public bool Update(T entity);
		public List<T> GetAll(Predicate<T> filter = null);
		public T Get(Predicate<T> filter = null);
	}
}

