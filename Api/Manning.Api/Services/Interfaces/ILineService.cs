using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Services.Interfaces
{
    public interface ILineService
    {
        Task<Zone> GetZoneById(int id);
        Task<Station> GetStationById(int id);
        Task<List<Zone>> GetAllZones();
        Task<List<Zone>> GetAllZonesAndStations();
        Task<List<Station>> GetAllStations();
        Task<List<ZoneStateDTO>> GetLineState();
        
    }
}
