using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pepelitto.Domain;
namespace Pepelitto.Domain.DataStructures
{
	public class Story
	{ 
		public Guid StoryID { get; set; } 
		public string StoryContentJson { get; set; }=String.Empty;
		public List<Guid> SeenList { get; set; } 


	}
}
