using ReactManningPoCAPI.Models;

namespace ReactManningPoCAPI.Services.Interfaces
{
    public interface ILineService
    {
        Task<List<Zone>> GetAllZones();
        Task<List<Zone>> GetAllZonesAndOpStations();
        Task<List<OpStation>> GetAllOpStations();
    }
}
