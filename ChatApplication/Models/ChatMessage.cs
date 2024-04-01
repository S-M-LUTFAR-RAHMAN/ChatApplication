using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChatApplication.Models
{
	public class ChatMessage
	{
		[Key]
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string Message { get; set; }
		public DateTime Time { get; set; } = DateTime.Now;

	}


	public class ChatDb : DbContext
	{
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public ChatDb() :base("ChatDb")
		{ 
		}
	}


}