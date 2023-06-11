using Manning.Api.Models;

namespace Manning.Api.Services.Interfaces
{
    public interface ILineService
    {
        Task<Zone> GetZoneById(int id);
        Task<OpStation> GetOpStationById(int id);
        Task<List<Zone>> GetAllZones();
        Task<List<Zone>> GetAllZonesAndOpStations();
        Task<List<OpStation>> GetAllOpStations();
    }
}
