using System;
using System.Collections.Generic;
using Entities.Interfaces;

namespace Entities.Models
{
	public class User:IEntities
	{
		public string UserName { get; set; }
		public List<Status> Statuses { get; set; }
		public DateTime Date { get; set; }
		public  int Id { get; set; } 

		public User()
		{
			Statuses = new List<Status>();
		}
	}
}

