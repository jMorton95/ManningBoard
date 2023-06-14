import { type TTrainingRequirement } from './LineTypes'

interface TFilteredRequirements {
  prerequisites: TTrainingRequirement[]
  standardOperatingProcedures: TTrainingRequirement[]
}

interface TRequirementPostData {
  requirementDescription: string
  stationID: number
}

export type { TFilteredRequirements, TRequirementPostData }
