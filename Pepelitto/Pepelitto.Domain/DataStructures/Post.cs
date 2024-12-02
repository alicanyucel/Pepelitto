using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepelitto.Domain.DataStructures
{
	public class Post
	{ 
		public Guid PostOwnerId { get; set; } 
		public List<string> Texts { get;set; }  

		
		public DateTime SharedTime { get; set; }
	}
}
