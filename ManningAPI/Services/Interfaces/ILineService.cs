using ManningApi.Models;

namespace ManningApi.Services.Interfaces
{
    public interface ILineService
    {
        Task<List<Zone>> GetAllZones();
        Task<List<Zone>> GetAllZonesAndOpStations();
        Task<List<OpStation>> GetAllOpStations();
    }
}
