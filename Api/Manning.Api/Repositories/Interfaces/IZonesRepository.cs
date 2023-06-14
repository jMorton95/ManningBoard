using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IZonesRepository : IBaseRepository<Zone>
    {
        Task<List<Zone>> GetAllZonesAndStations();
    }
}
