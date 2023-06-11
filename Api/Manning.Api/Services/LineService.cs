﻿using Manning.Api.Models;
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

        public async Task<List<OpStation>> GetAllOpStations() => await _opStationRepository.GetAllOpStationsAsync();

        public async Task<Zone> GetZoneById(int id) => await _zonesRepository.GetById(id);
        public async Task<OpStation> GetOpStationById(int id) => await _opStationRepository.GetOpStationByID(id);
    }
}