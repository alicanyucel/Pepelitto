using AutoMapper;
using GenericRepository;
using MediatR;
using Pepelitto.Domain.Entities;
using Pepelitto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Pepelitto.Application.Features.User.Createuser
{
    internal sealed class CreateUserComamndHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateUserCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            AppUser appUser = mapper.Map<AppUser>(request);
            await userRepository.AddAsync(appUser, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Kullanıcı kaydı yapıldı"
;
        }
    }
}
