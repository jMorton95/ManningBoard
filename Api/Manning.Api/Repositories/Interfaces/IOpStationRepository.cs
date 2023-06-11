using Manning.Api.Models;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IOpStationRepository
    {
        Task<List<OpStation>> GetAllOpStationsAsync(); 
        List<OpStation> GetAllOpStations();
        Task<List<OpStation>> GetOpStationsByZoneID(int zoneID);
        Task<OpStation> GetOpStationByID(int ID);
        Task<List<int>> GetOpStationTrainingIDs(int opstationID);
    }
}
