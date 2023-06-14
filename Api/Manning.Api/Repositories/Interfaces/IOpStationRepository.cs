using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IOpStationRepository : IBaseRepository<Station>
    {
        Task<List<Station>> GetAllOpStations();
        Task<List<Station>> GetOpStationsByZoneID(int zoneID);
        Task<Station> GetOpStationByID(int ID);
        Task<List<int>> GetOpStationTrainingIDs(int opstationID);
        Task<Station> AddOperatorToOpStation(OperatorAndStationIdDTO dto);
        void RemoveOperatorFromOpStation(OperatorAndStationIdDTO dto);
        
    }
}
