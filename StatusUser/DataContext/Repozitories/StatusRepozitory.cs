using System;
using System.Collections.Generic;
using DataContext.Interfaces;
using Entities.Models;

namespace DataContext.Repozitories
{
	public class StatusRepozitory:IRepozitory<Status>
	{
		public StatusRepozitory()
		{
		}

        public bool Create(Status entity)
        {
            try
            {
                DbContext.Statuses.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Delate(Status entity)
        {
            try
            {
                DbContext.Statuses.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Status Get(Predicate<Status> filter )
        {
            try
            {
                return DbContext.Statuses.Find(filter);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<Status> GetAll(Predicate<Status> filter = null)
        {
            try
            {
                if (filter!=null)
                {
                    return DbContext.Statuses.FindAll(filter);
                }
                return DbContext.Statuses;

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public bool Update(Status entity)
        {
            try
            {
                Status existStatus = Get(x => x.Id == entity.Id);
                existStatus = entity;
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }


        }
    }
}

