using ReactManningPoCAPI.Models;
using ReactManningPoCAPI.Repositories.Interfaces;
using ReactManningPoCAPI.Services.Interfaces;

namespace ReactManningPoCAPI.Services
{
    public class LineService : ILineService
    {
        private readonly IZonesRepository _zonesRepository;
        private readonly IOpStationRepository _opStationRepository;
        public LineService(IZonesRepository zonesRepository, IOpStationRepository opStationRepository)
        {
            _zonesRepository = zonesRepository;
            _opStationRepository = opStationRepository;
        }

        public async Task<List<Zone>> GetAllZones() => await _zonesRepository.GetAll();

        public async Task<List<Zone>> GetAllZonesAndOpStations() => await _zonesRepository.GetAllZonesAndOpStations();

        public async Task<List<OpStation>> GetAllOpStations() => await _opStationRepository.GetAllOpStationsAsync();
    }
}
