using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Pepelitto.Application.Features.User.UpdateUsers
{
    public sealed record UpdateUserCommand(Guid Id,string FirstName, string LastName, string Email,string Phone,string City, string Town,string Address) : IRequest<Result<string>>;
}
