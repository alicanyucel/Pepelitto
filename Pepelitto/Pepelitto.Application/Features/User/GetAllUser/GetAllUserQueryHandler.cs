using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pepelitto.Domain.Entities;
using Pepelitto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Pepelitto.Application.Features.User.GetAllUsersQuery;

internal sealed class GetAllUserQueryHandler(
    IUserRepository userRepository) : IRequestHandler<GetAllUsersQuery, Result<List<AppUser>>>
{
    public async Task<Result<List<AppUser>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        List<AppUser> appusers = await userRepository.GetAll().OrderBy(p => p.FirstName).ToListAsync(cancellationToken);

        return appusers;
    }
}
