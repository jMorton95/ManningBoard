import { type Base } from './BaseType';

type TZone = Base & {
  zoneName: string
  stations: TStationWithTraining[] | null
}

type TStationWithTraining = TStation & {
  trainingRequirements: TTrainingRequirement[]
}
type TStation = Base & {
  stationName: string
  zoneID: number
}

type TTrainingRequirement = Base & {
  requirementDescription: string
  stationID: number
}

export type { TZone, TStation, TTrainingRequirement };
