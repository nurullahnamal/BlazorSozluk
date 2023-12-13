using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorSozluk.Api.Application.Interfaces.Repositories;
using BlazorSozluk.Common.Events.User;
using BlazorSozluk.Common.Infrastructure;
using BlazorSozluk.Common.Infrastructure.Exceptions;
using MediatR;

namespace BlazorSozluk.Api.Application.Features.Commands.User.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {
        private readonly IUserRepository userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            if (!request.UserId.HasValue)
                throw new ArgumentNullException(nameof(request.UserId));

            var dbuser = await userRepository.GetByIdAsync(request.UserId.Value);

            if (dbuser is null)
                throw new DatabaseValidationException("User not found");

            var encPass = PasswordEncryptor.Encrpt(request.OldPassword);
            if (dbuser.Password != request.OldPassword)
                throw new DatabaseValidationException("Old password wrong");
            dbuser.Password = encPass;
            await userRepository.UpdateAsync(dbuser);
            return true;
        }
    }
}
