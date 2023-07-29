using System;
using System.Collections.Generic;
using Business.Interfaces;
using DataContext.Repozitories;
using Entities.Models;

namespace Business.Services
{
	public class UserServices: IBusines<User>
    {
        private readonly UserRepozitory userRepozitory;
        private readonly StatusRepozitory statusRepozitory;
        private static int _count { get; set; } = 1;
		public UserServices()
		{
            userRepozitory = new UserRepozitory();
            statusRepozitory = new StatusRepozitory();
		}

        public User Create(User user)
        {
           
            try
            {
                user.Id = _count;
                user.Date = DateTime.Now;
                if (userRepozitory.Get(x => x.Id == user.Id) == null)
                {
                    userRepozitory.Create(user);
                    _count++;
                    return user;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User Delete(int id)
        {
            try
            {
                User user = userRepozitory.Get(x => x.Id == id);
                if (user!=null)
                {
                    userRepozitory.Delate(user);
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<User> GetAll()
        {
            if (userRepozitory.GetAll().Count==0)
            {
                return null;
            }
            return userRepozitory.GetAll();
        }

        public User GetById(int id)
        {
            try
            {
                if (userRepozitory.Get(x => x.Id == id) == null||GetAll()==null)
                {
                    return null;
                }
                return userRepozitory.Get(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User GetByName(string userName)
        {
            try
            {
                if (userRepozitory.Get(x=>x.UserName==userName)==null|| GetAll() == null)
                {
                    return null;
                }
                return userRepozitory.Get(x => x.UserName == userName);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User Update(User user)
        {
            try
            {
                if (GetById(user.Id)!=null)
                {
                    userRepozitory.Update(user);
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

