using System;
using System.Collections.Generic;
using Entities.Models;

namespace DataContext
{
	public static class DbContext
	{
		public static List<User> User { get; set; }
		public static List<Status> Statuses { get; set; }
		static DbContext()
		{
			User = new List<User>();
			Statuses = new List<Status>();
		}
	}
}

