using System;
using System.Collections.Generic;
using Entities.Interfaces;

namespace Business.Interfaces
{
	public interface IBusines<T>where T:IEntities
	{
        public T Create(T entity);
        public T Delete(int id);
        public T Update(T entity);
        public T GetById(int id);
        public List<T> GetAll();
        public T GetByName(string name);
    }
}

