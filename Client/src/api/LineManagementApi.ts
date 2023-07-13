import { type TStationAssignableOperatorsDTO } from "@/types/dtos/StationAssignableOperators";
import { type TOperator } from "@/types/models/Operator";
import { GET, PostWithBodyNoReturnData } from "./BaseApi";

type TLineManagementApi = {
  GetStationAssignableOperators: (stationID: number) => Promise<TStationAssignableOperatorsDTO | undefined>;
  AddOperatorToStation: (operatorID: number, stationID: number, isTrainee: boolean) => Promise<boolean>;
  RemoveOperatorFromStation: (operatorID: number, stationID: number) => Promise<boolean>
}

type TLineManagementApiExport = (operator: TOperator, token: string) => TLineManagementApi | null

export const LineManagementApi: TLineManagementApiExport = (operator: TOperator, token: string) => {

  if (!operator.isAdministrator) {
    return null;
  }

  const GetStationAssignableOperators = async(stationID: number) => await GET<TStationAssignableOperatorsDTO>(`StationManagement/${stationID}`, token);

  const AddOperatorToStation = async(operatorID: number, stationID: number, isTrainee: boolean = false) => {
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
