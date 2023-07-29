using System;
using Business.Services;
using Entities.Models;
using Utilities;

namespace StatusUser.Controller
{
	public class UserController
	{
		StatusServices statusServices;
		UserServices userServices;
        public UserController()
		{
			statusServices = new StatusServices();
			userServices = new UserServices();
		}
		public void Create()
		{
			User user = new User();
			Helper.SetMessageAndColor("Enter User Name", ConsoleColor.Green);
			string userName = Console.ReadLine();
			user.UserName = userName;
			var newUser = userServices.Create(user);
			if (newUser==null)
			{
				Helper.SetMessageAndColor("something went wrong", ConsoleColor.Red);
				return;
			}
			
			var status = statusServices.GetAll();
			if (status != null)
			{
                foreach (var item in status)
                {
					if (item.User.Id==newUser.Id)
					{
						newUser.Statuses.Add(item);
					}
                }
            }
			Helper.SetMessageAndColor("user succesfully created:", ConsoleColor.Cyan);
			
		}
		public void Delete()
		{
			Id: Helper.SetMessageAndColor("enter user id for delete:", ConsoleColor.Green);
			string stringId = Console.ReadLine();
			int id;
			if (!Int32.TryParse(stringId,out id))
			{
				Helper.SetMessageAndColor("enter correct Id", ConsoleColor.Red);
				goto Id;
			}
			var deletingUser=userServices.Delete(id);
			if (deletingUser==null)
			{
				Helper.SetMessageAndColor("user not found:", ConsoleColor.Red);
				return;
			}
			Helper.SetMessageAndColor("user succesfully deleted", ConsoleColor.Cyan);
			var status = statusServices.GetAll();
			if (status!=null)
			{
				foreach (var item in status)
				{
					if (item.User.Id==deletingUser.Id)
					{
						statusServices.Delete(item.Id);
						if (status.Count==0)
						{
							return;
						}
					}
				}
			}
		}
		public void GetById()
		{
			Id: Helper.SetMessageAndColor("enter user Id ", ConsoleColor.Green);
			string stringId = Console.ReadLine();
			int id;
			if (!Int32.TryParse(stringId, out id))
			{
				Helper.SetMessageAndColor("enter correct id:", ConsoleColor.Red);
				goto Id;
			}
			var user = userServices.GetById(id);
			if (user==null)
			{
				Helper.SetMessageAndColor("user not found", ConsoleColor.Red);
				return;
			}
			Helper.SetMessageAndColor($"{user.Id} {user.UserName}", ConsoleColor.Cyan);
			var status = statusServices.GetAll();
			if (status!=null)
			{
                foreach (var item in status)
                {
					if (item.User.Id==user.Id)
					{
						Helper.SetMessageAndColor($"User Statuses:{item.Id} {item.Title} {item.Date} {item.Context}", ConsoleColor.Yellow);
					}
                }
            }
		}
		public void GetAll()
		{
			var users = userServices.GetAll();
			if (users==null)
			{
				Helper.SetMessageAndColor("not founded active users:", ConsoleColor.Red);
				return;
			}
			foreach (var item in users)
			{
				Helper.SetMessageAndColor($"{item.Id} {item.UserName} {item.Date}", ConsoleColor.Cyan);
			}
		}
        public void GetByName()
        {
			Helper.SetMessageAndColor("enter user Name ", ConsoleColor.Green);
            string name = Console.ReadLine();
            var user = userServices.GetByName(name);
            if (user == null)
            {
                Helper.SetMessageAndColor("user not found", ConsoleColor.Red);
                return;
            }
            Helper.SetMessageAndColor($"{user.Id} {user.UserName}", ConsoleColor.Cyan);
            var status = statusServices.GetAll();
            if (status != null)
            {
                foreach (var item in status)
                {
                    if (item.User.Id == user.Id)
                    {
                        Helper.SetMessageAndColor($"User Statuses:{item.Id} {item.Title} {item.Date} {item.Context}", ConsoleColor.Yellow);
                    }
                }
            }
        }
		public void Update()
		{
			Id: Helper.SetMessageAndColor("enter user id for update:", ConsoleColor.Cyan);
            string stringId = Console.ReadLine();
            int id;
            if (!Int32.TryParse(stringId, out id))
            {
                Helper.SetMessageAndColor("something went wrong", ConsoleColor.Red);
                goto Id;
            }
			var user = userServices.GetById(id);
			if (user==null)
			{
				Helper.SetMessageAndColor("user not found", ConsoleColor.Red);
				return;
			}
			Helper.SetMessageAndColor("enter new user name", ConsoleColor.Cyan);
			user.UserName = Console.ReadLine();
			var statuses=statusServices.GetAll();
			for (int i = 0; i < statuses.Count; i++)
			{
				if (statuses[i].User.Id==user.Id)
				{
					statuses[i].User = user;
				}
			}
			var newUser=userServices.Update(user);
			if (newUser==null)
			{
				Helper.SetMessageAndColor("something went wrong", ConsoleColor.Red);
				return;
			}
			Helper.SetMessageAndColor("user succesfully updated", ConsoleColor.Cyan);
        }
    }
}

