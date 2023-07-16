import { type TStationAssignableOperatorsDTO } from "@/types/dtos/StationAssignableOperators";
import { GET, PostWithBodyNoReturnData } from "./BaseApi";

export type TLineManagementApi = (token: string) => {
  GetStationAssignableOperators: (stationID: number) => Promise<TStationAssignableOperatorsDTO | undefined>;
  AddOperatorToStation: (operatorID: number, stationID: number, isTrainee: boolean) => Promise<boolean>;
  RemoveOperatorFromStation: (operatorID: number, stationID: number) => Promise<boolean>
}

export const LineManagementApi: TLineManagementApi = (token: string) => {
 
  const GetStationAssignableOperators = async(stationID: number) => await GET<TStationAssignableOperatorsDTO>(`StationManagement/${stationID}`, token);

  const AddOperatorToStation = async(operatorID: number, stationID: number, isTrainee = false) => {
    const resp = await PostWithBodyNoReturnData("StationManagement/AddOperatorToStation", {operatorID, stationID, isTrainee}, token)
    return (resp.status === 200)
  }

  const RemoveOperatorFromStation = async(operatorID: number, stationID: number) => {
    const resp = await PostWithBodyNoReturnData("StationManagement/RemoveOperatorFromStation", {operatorID, stationID}, token)
    return (resp.status === 200)
  }

  return {
    GetStationAssignableOperators,
    AddOperatorToStation,
    RemoveOperatorFromStation
  }
}
