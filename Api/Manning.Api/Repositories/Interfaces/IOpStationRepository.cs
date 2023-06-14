using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;

namespace Manning.Api.Repositories.Interfaces
{
    public interface IOpStationRepository : IBaseRepository<OpStation>
    {
        Task<List<OpStation>> GetAllOpStations();
        Task<List<OpStation>> GetOpStationsByZoneID(int zoneID);
        Task<OpStation> GetOpStationByID(int ID);
        Task<List<int>> GetOpStationTrainingIDs(int opstationID);
        Task<OpStation> AddOperatorToOpStation(OperatorAndStationIdDTO dto);
        void RemoveOperatorFromOpStation(OperatorAndStationIdDTO dto);
        
    }
}
