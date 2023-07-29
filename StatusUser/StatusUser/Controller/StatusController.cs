using System;
using Business.Services;
using Entities.Models;
using Utilities;

namespace StatusUser.Controller
{
	public class StatusController
	{
        StatusServices statusService;
		UserServices userServices;
		public StatusController()
		{
			statusService = new StatusServices();
			userServices = new UserServices();
		}
		public void Create()
		{
			Id: Helper.SetMessageAndColor("Enter user Id", ConsoleColor.Cyan);
			string stringId = Console.ReadLine();
			int id;
			if (!Int32.TryParse(stringId,out id))
			{
				Helper.SetMessageAndColor("enter correct id", ConsoleColor.Red);
				goto Id;
			}
			var user=userServices.GetById(id);
			if (user==null)
			{
				Helper.SetMessageAndColor("user not found:", ConsoleColor.Red);
				return;
			}
			Status status = new Status();
			status.User = user;
			Helper.SetMessageAndColor("enter status title", ConsoleColor.Cyan);
			string title = Console.ReadLine();
			Helper.SetMessageAndColor("enter status context", ConsoleColor.Cyan);
			string context = Console.ReadLine();
			status.Context = context;
			status.Title = title;
			Status newStatus=statusService.Create(status);
			if (newStatus!=null)
			{
				Helper.SetMessageAndColor("status succesfully created:", ConsoleColor.Yellow);
				return;
			}
			Helper.SetMessageAndColor("something went wrong", ConsoleColor.Red);
		}
		public void Delete()
		{
			Id: Helper.SetMessageAndColor("enter status id for delete", ConsoleColor.Cyan);
			string stringId = Console.ReadLine();
			int id;
			if (!Int32.TryParse(stringId,out id))
			{
				Helper.SetMessageAndColor("something went wrong", ConsoleColor.Red);
				goto Id;
			}
            var status = statusService.GetById(id);
			var users = userServices.GetAll();
			if (users!=null)
			{
                foreach (var item in users)
                {
                    foreach (var i in item.Statuses)
                    {
                        if (i.Id == status.Id)
                        {
                            item.Statuses.Remove(i);
                        }
                    }
                }
            }
			
            var deletingStatus = statusService.Delete(status.Id);
			if (deletingStatus==null)
			{
				Helper.SetMessageAndColor("something went wrong", ConsoleColor.Red);
				return;
			}
			Helper.SetMessageAndColor("status succesfully deleted", ConsoleColor.Yellow);

		}
		public void GetById()
		{
			Id: Helper.SetMessageAndColor("enter status Id:", ConsoleColor.Cyan);
			string stringId = Console.ReadLine();
			int id;
			if (!Int32.TryParse(stringId,out id))
			{
				Helper.SetMessageAndColor("enter correct id", ConsoleColor.Red);
				goto Id;
			}
			var status = statusService.GetById(id);
			if (status==null)
			{
				Helper.SetMessageAndColor("status not found", ConsoleColor.Red);
				return;
			}
			Helper.SetMessageAndColor($"{status.Id} {status.Title} {status.Context} {status.Date} {status.User.UserName}", ConsoleColor.Yellow);
		}
        public void GetByTitle()
        {
			Helper.SetMessageAndColor("enter status title:", ConsoleColor.Cyan);
            string title = Console.ReadLine();
            var status = statusService.GetByName(title);
            if (status == null)
            {
                Helper.SetMessageAndColor("status not found", ConsoleColor.Red);
                return;
            }
            Helper.SetMessageAndColor($"{status.Id} {status.Title} {status.Context} {status.Date}", ConsoleColor.Yellow);
        }
		public void GetAll()
		{
			var statuses = statusService.GetAll();
			if (statuses==null)
			{
				Helper.SetMessageAndColor("not found active statuses", ConsoleColor.Red);
				return;
			}
			foreach (var item in statuses)
			{
				Helper.SetMessageAndColor($"{item.Id} {item.Title} {item.Context} {item.Date}", ConsoleColor.Yellow);
			}
		}
		public void Update()
		{
			Id: Helper.SetMessageAndColor("enter id for update status", ConsoleColor.Cyan);
			string stringId = Console.ReadLine();
			int id;
			if (!Int32.TryParse(stringId,out id))
			{
				Helper.SetMessageAndColor("something went wrong", ConsoleColor.Red);
				goto Id;
			}
			var status=statusService.GetById(id);
			if (status==null)
			{
				Helper.SetMessageAndColor("status not found", ConsoleColor.Red);
				return;
			}
			Helper.SetMessageAndColor("enter new title", ConsoleColor.Cyan);
			status.Title = Console.ReadLine();
			Helper.SetMessageAndColor("enter new status context:", ConsoleColor.Cyan);
			status.Context = Console.ReadLine();
			var user = userServices.GetById(status.User.Id);
			for (int i = 0; i < user.Statuses.Count; i++)
			{
                if (user.Statuses[i].Id == status.Id)
                {
					user.Statuses[i] = status;
                }
            }
			var newStatus=statusService.Update(status);
			if (newStatus==null)
			{
				Helper.SetMessageAndColor("something went wrong", ConsoleColor.Red);
				return;
			}
			Helper.SetMessageAndColor("status succesfully updated", ConsoleColor.Green);
		}
    }
}

