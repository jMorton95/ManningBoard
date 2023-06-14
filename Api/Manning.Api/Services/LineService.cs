using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;

namespace Manning.Api.Services
{
    public class LineService : ILineService
    {
        private readonly IZonesRepository _zonesRepository;
        private readonly IStationRepository _stationRepository;
        public LineService(IZonesRepository zonesRepository, IStationRepository stationRepository)
        {
            _zonesRepository = zonesRepository;
            _stationRepository = stationRepository;
        }

        public async Task<List<Zone>> GetAllZones() => await _zonesRepository.GetAll();

        public async Task<List<Zone>> GetAllZonesAndStations() => await _zonesRepository.GetAllZonesAndStations();

        public async Task<List<Station>> GetAllStations() => await _stationRepository.GetAllStations();

        public async Task<Zone> GetZoneById(int id) => await _zonesRepository.GetById(id);
        public async Task<Station> GetStationById(int id) => await _stationRepository.GetStationByID(id);
        
    }
}
