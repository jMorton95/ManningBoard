import { type TTrainingRequirement } from './models/LineTypes';

type TFilteredRequirements = {
  prerequisites: TTrainingRequirement[]
  standardOperatingProcedures: TTrainingRequirement[]
}

type TRequirementPostData = {
  requirementDescription: string
  stationID: number
}

export type { TFilteredRequirements, TRequirementPostData };
