using System;
using Entities.Interfaces;

namespace Entities.Models
{
    public class Status : IEntities
    {
        public string Title { get; set; }
        public string Context { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public  int Id { get; set; } 

        public Status()
		{
		}
	}
}

