using ChatApplication.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Hubs
{
	public class Chathub:Hub
	{
		readonly ChatDb db; 
        public Chathub()
        {
			db = new ChatDb();
        }




        public void SendMessage(string name, string message)
		{
			// Call the addNewMessageToPage method to update clients.
			Clients.All.addNewMessageToPage(name, message);
			//Clients.All.SendAsync("addNewMessageToPage", name, message);

			var chatMsg = new ChatMessage()
			{
				Message = message,
				SenderName = name
			};
			db.ChatMessages.Add(chatMsg);
			db.SaveChanges();
		}


		public override Task OnConnected()
		{
			var data = db.ChatMessages.ToList().OrderByDescending(d=> d.Time).Take(10).OrderBy(r=> r.Time);
			Clients.Caller.LoadData(data);

			return base.OnConnected();
		}

		


	}
}
