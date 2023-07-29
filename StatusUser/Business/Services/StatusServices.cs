using System;
using System.Collections.Generic;
using Business.Interfaces;
using DataContext.Repozitories;
using Entities.Models;

namespace Business.Services
{
	public class StatusServices:IBusines<Status>
	{
        private readonly UserRepozitory userRepozitory;
        private readonly StatusRepozitory statusRepozitory;
        private static int _count { get; set; } = 1;
        public StatusServices()
		{
            userRepozitory = new UserRepozitory();
            statusRepozitory = new StatusRepozitory();
		}

        public Status Create(Status status)
        {
            try
            {
                status.Id = _count;
                status.Date = DateTime.Now;
                if (statusRepozitory.Get(x => x.Id == status.Id) == null)
                {
                    statusRepozitory.Create(status);
                    _count++;
                    return status;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Status Delete(int id)
        {
            try
            {
                Status existStatus = statusRepozitory.Get(x => x.Id == id);
                if (existStatus==null)
                {
                    return null;
                }
                statusRepozitory.Delate(existStatus);
                return existStatus;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Status> GetAll()
        {
            try
            {
                if (statusRepozitory.GetAll().Count == 0)
                {
                    return null;
                }
                return statusRepozitory.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Status GetById(int id)
        {
            try
            {
                Status existStatus = statusRepozitory.Get(x => x.Id == id);
                if (existStatus == null||GetAll()==null)
                {
                    return null;
                }
                return existStatus;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Status GetByName(string title)
        {
            try
            {
                Status existStatus = statusRepozitory.Get(x => x.Title == title);
                if (existStatus==null||GetAll()==null)
                {
                    return null;
                }
                return existStatus;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Status Update(Status status)
        {
            try
            {
                if (GetById(status.Id)!=null)
                {
                     statusRepozitory.Update(status);
                    return status;
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

