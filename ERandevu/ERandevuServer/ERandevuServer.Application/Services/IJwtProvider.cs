using ERandevuServer.Domain.Entities;

namespace ERandevuServer.Application.Services
{
    public interface IJwtProvider
    {
        string CreateToken(AppUser user);
    }
}
