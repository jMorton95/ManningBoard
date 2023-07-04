import { type TTrainingRequirement } from "@/types/models/LineTypes"
import { type TOperator } from "@/types/models/Operator"
import { PostWithBody } from "./BaseApi"
import { type AddRequirementDTO } from "@/types/dtos/PostRequestDTO"

export type TStationManagementApiExport = (operator: TOperator, token: string) => TStationManagementApi | null

type TStationManagementApi = {
  AddTrainingRequirement: (requirementDescription: string, stationID: number) => Promise<TTrainingRequirement | undefined>
}

export const StationManagementApi: TStationManagementApiExport = (operator: TOperator, token: string) => {

  if (!operator.isAdministrator || !token) {
    return null;
  }

  const AddTrainingRequirement = async(requirementDescription: string, stationID: number) => {
    const trainingRequirement = await PostWithBody<TTrainingRequirement, AddRequirementDTO>("TrainingRequirement", {requirementDescription, stationID}, token);
    return trainingRequirement
  }

  return {AddTrainingRequirement}
}