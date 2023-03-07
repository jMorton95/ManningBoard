using ReactManningPoCAPI.Models;

namespace ReactManningPoCAPI.Repositories.Interfaces
{
    public interface IZonesRepository : IBaseRepository<Zone>
    {
        Task<List<Zone>> GetAllZonesAndOpStations();
    }
}
