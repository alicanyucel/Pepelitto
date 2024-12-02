using Microsoft.AspNetCore.Identity;
using Pepelitto.Domain.DataStructures;

namespace Pepelitto.Domain.Entities
{
    public enum LoginType:int { Email=1,User} 
    public sealed class AppUser : IdentityUser<Guid>
    {
        public string UserId { get; set; } = string.Empty; 
        public string FirstName { get; set; } = string.Empty; 
        
        public string LastName { get; set; } = string.Empty; 
        public string FullName => string.Join(" ", FirstName, LastName); 
        public string Email { get; set; }=string.Empty; 
        public string Password { get; set; }=string.Empty; 
        public bool EmailConfirmed { get; set; } 
        public LoginType LoginType { get; set; }
        public bool IsPremium { get; set; } = false;
		//IsProfileHidden: Profil gizli mi değil mi
		public bool IsProfileHidden { get; set; }=false; 
        //IsProfileHidden: Profil gizli mi değil mi
        public List<Story> Stories { get; set; }=new();  
        //  Stories:Hikayeler
        // Guid: AppUser guid 

        public List<Guid> Followings { get; set; }=new();
		// Followings:Takipçileri
		// Guid: AppUser guid   
		public List<Guid> Followers { get; set; }=new();
        // Followings:Takipçileri
        // Guid: AppUser guid  
        public List<Post> Posts { get; set; } = new(); 
        public List<UserTag> UserTags { get; set; } = new();  


		public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpires { get; set; }
    }
}
