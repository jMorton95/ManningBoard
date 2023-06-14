interface TZone {
  id: number
  zoneName: string
  opStations: TOpStation[]
}

interface TOpStation {
  id: number
  stationName: string
  zoneID: number
  trainingRequirements: TTrainingRequirement[]
}

interface TTrainingRequirement {
  id: number
  requirementDescription: string
  opStationID: number
}

export type { TZone, TOpStation, TTrainingRequirement }
