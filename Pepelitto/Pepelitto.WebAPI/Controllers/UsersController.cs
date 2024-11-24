using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pepelitto.Application.Features.User.Createuser;
using Pepelitto.Application.Features.User.GetAllUsersQuery;
using Pepelitto.Application.Features.User.RemoveUserById;
using Pepelitto.Application.Features.User.UpdateUsers;
using Pepelitto.WebAPI.Abstractions;

namespace Pepelitto.WebAPI.Controllers
{
    [AllowAnonymous]
    public class UsersController : ApiController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }
        // TEST EDİLDİ SAĞLAM
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);

        }
        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
