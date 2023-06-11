using ManningApi.Models;

namespace ManningApi.Repositories.Interfaces
{
    public interface IZonesRepository : IBaseRepository<Zone>
    {
        Task<List<Zone>> GetAllZonesAndOpStations();
    }
}
