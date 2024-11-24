using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Pepelitto.Application.Features.User.RemoveUserById
{
    public sealed record DeleteUserByIdCommand(
     Guid Id) : IRequest<Result<string>>;
}
