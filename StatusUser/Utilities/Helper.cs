using System;
namespace Utilities
{
	public static class Helper
	{
		public static void SetMessageAndColor(string message,ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine(message);
			Console.ResetColor();
		}
	}
    public enum user
    {
        CreateUser = 1,
        DeleteUser,
        UpdateUser,
        GetUserById,
        GetUserByName,
        GetAllUser
    }
    public enum status
	{
		CreateStatus=7,
		DeleteStatus,
		UpdateStatus,
		GetStatusById,
		GetStatusByTitle,
		GetAllStatus
	}
}

