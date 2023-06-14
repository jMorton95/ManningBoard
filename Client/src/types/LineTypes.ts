interface TZone {
  id: number
  zoneName: string
  stations: TStation[]
}

interface TStation {
  id: number
  stationName: string
  zoneID: number
  trainingRequirements: TTrainingRequirement[]
}

interface TTrainingRequirement {
  id: number
  requirementDescription: string
  stationID: number
}

export type { TZone, TStation, TTrainingRequirement }
