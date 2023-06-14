using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Services.Interfaces
{
    public interface ILineService
    {
        Task<Zone> GetZoneById(int id);
        Task<Station> GetOpStationById(int id);
        Task<List<Zone>> GetAllZones();
        Task<List<Zone>> GetAllZonesAndOpStations();
        Task<List<Station>> GetAllOpStations();
        
    }
}
