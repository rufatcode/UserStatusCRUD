using System;
using System.Collections.Generic;
using DataContext.Interfaces;
using Entities.Models;

namespace DataContext.Repozitories
{
	public class UserRepozitory:IRepozitory<User>
	{
		public UserRepozitory()
		{
		}

        public bool Create(User entity)
        {
            try
            {
                DbContext.User.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Delate(User entity)
        {
            try
            {
                DbContext.User.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User Get(Predicate<User> filter)
        {
            try
            {

                return DbContext.User.Find(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public List<User> GetAll(Predicate<User> filter = null)
        {
            try
            {
                if (filter!=null)
                {
                    return DbContext.User.FindAll(filter);
                }
                return DbContext.User;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public bool Update(User entity)
        {
            
            try
            {
                User exsitUser = Get(x => x.Id == entity.Id);
                exsitUser = entity;
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

