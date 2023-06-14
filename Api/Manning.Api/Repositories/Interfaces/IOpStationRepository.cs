using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IStationRepository : IBaseRepository<Station>
    {
        Task<List<Station>> GetAllStations();
        Task<List<Station>> GetStationsByZoneID(int zoneID);
        Task<Station> GetStationByID(int ID);
        Task<List<int>> GetStationTrainingIDs(int stationID);
        Task<Station> AddOperatorToStation(OperatorAndStationIdDTO dto);
        void RemoveOperatorFromStation(OperatorAndStationIdDTO dto);
        
    }
}
