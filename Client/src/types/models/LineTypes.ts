import { type Base } from './BaseType';

type TZone = Base & {
  id: number
  zoneName: string
  stations: TStation[] | null
}

type TStation = Base & {
  id: number
  stationName: string
  zoneID: number
  trainingRequirements: TTrainingRequirement[]
}

type TTrainingRequirement = Base & {
  requirementDescription: string
  stationID: number
}

export type { TZone, TStation, TTrainingRequirement };
