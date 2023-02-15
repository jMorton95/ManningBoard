using ReactManningPoCAPI.Models;

namespace ReactManningPoCAPI.Repositories.Interfaces
{
    public interface IZonesRepository
    {
        Task<List<Zone>> GetAllZones();
        Task<List<Zone>> GetAllZonesAndOpStations();
    }
}
