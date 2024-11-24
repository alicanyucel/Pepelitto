using AutoMapper;
using GenericRepository;
using MediatR;
using Pepelitto.Domain.Entities;
using Pepelitto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace Pepelitto.Application.Features.User.UpdateUsers;


internal sealed class UpdateCustomerCommandHandler(
 IUserRepository customerRepository,
 IUnitOfWork unitOfWork,
 IMapper mapper) : IRequestHandler<UpdateUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        AppUser appUser = await customerRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

        if (appUser is null)
        {
            return Result<string>.Failure("Kullanıcı bulunamadı");
        }

        if (appUser.Id != request.Id)
        {
            bool isUserById = await customerRepository.AnyAsync(p => p.Id == request.Id, cancellationToken);

            if (isUserById)
            {
                return Result<string>.Failure("Kullanıcı daha önce kaydedilmiş");
            }
        }

        mapper.Map(request, appUser);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Kullanıcı bilgileri başarıyla güncellendi";
    }
}
