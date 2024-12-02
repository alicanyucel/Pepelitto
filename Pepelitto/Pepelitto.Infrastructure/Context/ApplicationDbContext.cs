using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pepelitto.Domain.DataStructures;
using Pepelitto.Domain.Entities;
using System.Reflection.Emit;

namespace Pepelitto.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<BlockInfo> Blocks { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<PostPhoto> PostPhotos { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Story> Stories { get; set; }
        DbSet<UserTag> UserTags { get; set; }
        DbSet<MessageInbox> MessagesInboxes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
            builder.Entity<Post>()
          .HasKey(p => p.PostOwnerId);
            builder.Entity<UserTag>()
        .HasKey(p => p.AppUserGuid);

            builder.Entity<BlockInfo>()
      .HasKey(p => p.BlockedUserGuid);

            builder.Entity<MessageInbox>()
    .HasKey(p => p.UserGuid);

            builder.Entity<PostPhoto>()
    .HasKey(p => p.PostPhotoId);

            builder.Entity<Message>()
   .HasKey(p => p.MesssageId);
            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityRoleClaim<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();
            builder.Ignore<IdentityUserClaim<Guid>>();
            //}
        }
    }
}