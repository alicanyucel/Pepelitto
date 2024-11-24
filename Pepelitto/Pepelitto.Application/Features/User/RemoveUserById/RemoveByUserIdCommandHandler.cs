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

namespace Pepelitto.Application.Features.User.RemoveUserById
{
    internal sealed class DeleteUserByIdCommandHandler(
     IUserRepository userRepository,
     IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = await userRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
            if (appUser is null)
            {
                return Result<string>.Failure("Kullanıcı Bulunamadı");
            }

            userRepository.Delete(appUser);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Kullanıcı başarılı bir şekilde siilindi.";
        }
    }
}
