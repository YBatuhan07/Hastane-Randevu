using ERandevuServer.Domain.Entities;
using ERandevuServer.Domain.Repositories;
using ERandevuServer.Infrastructure.Context;
using GenericRepository;

namespace ERandevuServer.Infrastructure.Repositories
{
    internal sealed class PatientRepository : Repository<Patient, ApplicationDbContext>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
