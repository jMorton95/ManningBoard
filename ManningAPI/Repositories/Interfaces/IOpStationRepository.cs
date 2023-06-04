﻿using ManningApi.Models;

namespace ManningApi.Repositories.Interfaces
{
    public interface IOpStationRepository
    {
        Task<List<OpStation>> GetAllOpStationsAsync(); 
        List<OpStation> GetAllOpStations();
        Task<List<OpStation>> GetOpStationsByZoneID(int zoneID);
        OpStation GetOpStationByID(int ID);
        List<int> GetOpStationTrainingIDs(int opstationID);
    }
}
