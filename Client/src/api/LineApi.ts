import { type LineStateDTO } from "@/types/dtos/LineState";
import { type TZone } from "@/types/models/LineTypes";
import { GET } from "./BaseApi";
import { type TStationAssignableOperatorsDTO } from "@/types/dtos/StationAssignableOperators";
import { type TOperator } from "@/types/models/Operator";

type TLineApi = {
  GetLineState: () => Promise<LineStateDTO | undefined>
  GetLine: () => Promise<TZone[] | undefined>
}

type TLineApiAuthenticated = {
  GetStationAssignableOperators: (stationID: number) => Promise<TStationAssignableOperatorsDTO | undefined>;
}

type TLineApiAuthenticatedExport = TLineApiAuthenticated | null

export const LineApi = (): TLineApi => {
  
  const GetLineState = async() => await GET<LineStateDTO>('Line/GetLineState');
  const GetLine = async() => await GET<TZone[]>('Line');

  return {
    GetLineState,
    GetLine
  };
}

export const LineApiAuthenticated = (operator: TOperator, token: string): TLineApiAuthenticatedExport => {

  if (!operator.isAdministrator) {
    return null;
  }

  const GetStationAssignableOperators = async(stationID: number) => await GET<TStationAssignableOperatorsDTO>(`StationManagement/${stationID}`, token);

  return {
    GetStationAssignableOperators
  }
}

