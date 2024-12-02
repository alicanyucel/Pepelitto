using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepelitto.Domain.DataStructures
{
	public class Message
	{
		public Guid From { get; set; }
		public Guid To { get; set; }
		public DateTime MessageTime {get;set;}
		public string MessageContentJson { get; set; } = string.Empty;
	}
}
