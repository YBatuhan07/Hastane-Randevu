using ERandevuServer.Application.Services;
using ERandevuServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERandevuServer.Application.Features.Auth.Login
{
    internal sealed class LoginCammandHandler(
        UserManager<AppUser> userManager,
        IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
    {
        public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            AppUser? appUser = 
                await userManager.Users.FirstOrDefaultAsync(p =>
                p.UserName == request.UserNameOrEmail ||
                p.Email == request.UserNameOrEmail, cancellationToken);

            if (appUser == null)
            {
                return Result<LoginCommandResponse>.Failure("Kullanıcı bulunamadı");
            }
            bool isPassowrdCorrect = await userManager.CheckPasswordAsync(appUser, request.Password);
            if (!isPassowrdCorrect)
            {
                return Result<LoginCommandResponse>.Failure("Yanlış şifre");
            }
            string token = jwtProvider.CreateToken(appUser);
            LoginCommandResponse response = new(token);
            return Result<LoginCommandResponse>.Succeed(response);
        }
    }
}
