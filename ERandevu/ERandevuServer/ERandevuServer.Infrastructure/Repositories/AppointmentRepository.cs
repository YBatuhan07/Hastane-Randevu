using ERandevuServer.Domain.Entities;
using ERandevuServer.Domain.Repositories;
using ERandevuServer.Infrastructure.Context;
using GenericRepository;

namespace ERandevuServer.Infrastructure.Repositories
{
    internal sealed class AppointmentRepository : Repository<Appointment, ApplicationDbContext>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
