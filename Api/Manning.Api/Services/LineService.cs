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
        private readonly IStationStateRepository _stationStateRepository;
        private readonly IOperatorService _operatorService;
        public LineService
        (
            IZonesRepository zonesRepository,
            IStationRepository stationRepository,
            IStationStateRepository stationStateRepository,
            IOperatorService operatorService
        )
        {
            _zonesRepository = zonesRepository;
            _stationRepository = stationRepository;
            _stationStateRepository = stationStateRepository;
            _operatorService = operatorService;
        }

        public async Task<List<Zone>> GetAllZones() => await _zonesRepository.GetAll();

        public async Task<List<Zone>> GetAllZonesAndStations() => await _zonesRepository.GetAllZonesAndStations();

        public async Task<List<Station>> GetAllStations() => await _stationRepository.GetAllStations();

        public async Task<Zone> GetZoneById(int id) => await _zonesRepository.GetById(id);
        public async Task<Station> GetStationById(int id) => await _stationRepository.GetStationByID(id);
        
        public async Task<List<ZoneStateDTO>> GetLineState()
        {
          var zones = await _zonesRepository.GetAllNoTracking();
          var stations = await _stationRepository.GetAll();

          var stationState = new List<StationStateDTO>();

          foreach (var station in stations)
          {
            List<StationStateModel?> state = await _stationStateRepository.GetStationStateByStationID(station.ID);
            var op = state.FirstOrDefault(s => !s.IsTrainee);
            var trainee = state.FirstOrDefault(s => s.IsTrainee);
            OperatorAndAvatarDTO operatorAndAvatar = (op != null) ? await _operatorService.GetOperatorAndAvatarByID(op.OperatorID) : null; 
            OperatorAndAvatarDTO traineeAndAvatar = (trainee != null) ? await _operatorService.GetOperatorAndAvatarByID(trainee.OperatorID) : null; 
            stationState.Add(new StationStateDTO() { Station = station, OperatorAndAvatar = operatorAndAvatar, TraineeAndAvatar = traineeAndAvatar });
            
          }

          var zoneState = new List<ZoneStateDTO>();

          foreach (var zone in zones){
            zoneState.Add(new ZoneStateDTO(){Zone = zone, StationStateDTOs = stationState.Where(x => x.Station!.ZoneID == zone.ID).ToList()});
          }

          return zoneState;
        }
    }
}
