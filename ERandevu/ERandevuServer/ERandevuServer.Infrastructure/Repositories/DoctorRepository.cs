using ERandevuServer.Domain.Entities;
using ERandevuServer.Domain.Repositories;
using ERandevuServer.Infrastructure.Context;
using GenericRepository;

namespace ERandevuServer.Infrastructure.Repositories
{
    internal sealed class DoctorRepository : Repository<Doctor, ApplicationDbContext>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
