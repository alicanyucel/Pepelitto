using GenericRepository;
using Pepelitto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pepelitto.Domain.Repositories
{
    public interface IUserRepository : IRepository<AppUser>
    {
    }
}
