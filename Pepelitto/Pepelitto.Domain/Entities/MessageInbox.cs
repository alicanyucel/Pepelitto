using Pepelitto.Domain.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepelitto.Domain.Entities
{
	public class MessageInbox
	{
		
		public Guid UserGuid { get;set; }  
		// gönderilen mesaj kime gitmiş 
		
		public Guid FromUserGuid { get;set; } 
		//Mesaj kimden gelmiş
		public List<Message> MessageList { get; set; } = new();
	}
}
