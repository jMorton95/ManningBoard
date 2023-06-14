using Manning.Api.Models;
using Manning.Api.Models.DataTransferObjects;
using Manning.Api.Repositories.Interfaces;
using Manning.Api.Services.Interfaces;

namespace Manning.Api.Services
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

        public async Task<List<Station>> GetAllOpStations() => await _opStationRepository.GetAllOpStations();

        public async Task<Zone> GetZoneById(int id) => await _zonesRepository.GetById(id);
        public async Task<Station> GetOpStationById(int id) => await _opStationRepository.GetOpStationByID(id);
        
    }
}
