import { TTrainingRequirement } from "./LineTypes"

type TFilteredRequirements = {
  prerequisites: TTrainingRequirement[],
  standardOperatingProcedures: TTrainingRequirement[]
}

type TRequirementPostData = {
  requirementDescription: string,
  opstationID: number
}

export type { TFilteredRequirements, TRequirementPostData}