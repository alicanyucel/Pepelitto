using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepelitto.Domain.DataStructures
{
	public enum BlockType:int
	{
		UnkownPage,BlockedInfo,HiddenProfile
	} 
	public class BlockInfo
	{
		 //deneme
		//Engellenen kullanıcının değişmez kimliğini yani AppUser sınıfının guid kimliğini işaret edecek 
		public Guid BlockedUserGuid; 
		//Kullanıcıyı Engelleme tipi
		public BlockType Type; 

	}
}
