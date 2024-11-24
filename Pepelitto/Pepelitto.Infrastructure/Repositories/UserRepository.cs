using GenericRepository;
using Pepelitto.Domain.Entities;
using Pepelitto.Domain.Repositories;
using Pepelitto.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepelitto.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<AppUser, ApplicationDbContext>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
