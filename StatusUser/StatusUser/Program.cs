using System;
using StatusUser.Controller;
using Utilities;

namespace StatusUser
{
    class Program
    {
        static void Main(string[] args)
        {
            StatusController statusController = new StatusController();
            UserController userController = new UserController();

            

            while (true)
            {
                Helper.SetMessageAndColor(
                @"
                    0-end of proses
                    1-Create user
                    2-Delete user
                    3-Update user
                    4-Get user by Id
                    5-Get user by Name
                    6-Get All users
                    7-create status for user
                    8-delete status
                    9-update status
                    10-get status by id
                    11-get status by title
                    12-get all status
                ", ConsoleColor.Cyan);
            Check: Helper.SetMessageAndColor("enter option for proses:", ConsoleColor.Green);
                string stringOption = Console.ReadLine();
                int option;
                if (!Int32.TryParse(stringOption,out option))
                {
                    Helper.SetMessageAndColor("something went wrong:", ConsoleColor.Red);
                    goto Check;
                }
                if (option==0)
                {
                    Helper.SetMessageAndColor("proses is finshed:", ConsoleColor.Yellow);
                    break;
                }
                switch (option)
                {
                    case (int)user.CreateUser:
                        userController.Create();
                        break;
                    case (int)user.DeleteUser:
                        userController.Delete();
                        break;
                    case (int)user.UpdateUser:
                        userController.Update();
                        break;
                    case (int)user.GetUserById:
                        userController.GetById();
                        break;
                    case (int)user.GetUserByName:
                        userController.GetByName();
                        break;
                    case (int)user.GetAllUser:
                        userController.GetAll();
                        break;
                    case (int)status.CreateStatus:
                        statusController.Create();
                        break;
                    case (int)status.DeleteStatus:
                        statusController.Delete();
                        break;
                    case (int)status.UpdateStatus:
                        statusController.Update();
                        break;
                    case (int)status.GetStatusById:
                        statusController.GetById();
                        break;
                    case (int)status.GetStatusByTitle:
                        statusController.GetByTitle();
                        break;
                    case (int)status.GetAllStatus:
                        statusController.GetAll();
                        break;
                    default:
                        break;
                }


            }
        }

    }
}

