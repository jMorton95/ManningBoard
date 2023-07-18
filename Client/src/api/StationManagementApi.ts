import { type TTrainingRequirement } from "@/types/models/LineTypes"
import { PostWithBody } from "./BaseApi"
import { type AddRequirementDTO } from "@/types/dtos/PostRequestDTO"

//export type TStationManagementApiExport = (operator: TOperator, token: string) => TStationManagementApi | null

export type TStationManagementApi = (token: string) => {
  AddTrainingRequirement: (requirementDescription: string, stationID: number) => Promise<TTrainingRequirement | undefined>
}

export const StationManagementApi: TStationManagementApi = (token: string) => {

  const AddTrainingRequirement = async(requirementDescription: string, stationID: number) => {
    const trainingRequirement = await PostWithBody<TTrainingRequirement, AddRequirementDTO>("TrainingRequirement", {requirementDescription, stationID}, token);
    return trainingRequirement
  }

  return {AddTrainingRequirement}
}