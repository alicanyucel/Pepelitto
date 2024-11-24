using MediatR;
using Pepelitto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Pepelitto.Application.Features.User.GetAllUsersQuery
{
public sealed record GetAllUsersQuery() : IRequest<Result<List<AppUser>>>;
}
