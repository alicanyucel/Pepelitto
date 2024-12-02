using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepelitto.Domain.DataStructures
{
	public class UserTag
	{ 
		public Guid AppUserGuid { get; set; } 
		public string TagName { get; set; }=String.Empty;

	}
}
