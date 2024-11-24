using Pepelitto.Application.Features.Auth.Login;
using Pepelitto.Domain.Entities;

namespace Pepelitto.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
