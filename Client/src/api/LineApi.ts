import { type LineStateDTO } from "@/types/dtos/LineState";
import { type TZone } from "@/types/models/LineTypes";
import { GET, PostWithBodyNoReturnData } from "./BaseApi";
import { type TStationAssignableOperatorsDTO } from "@/types/dtos/StationAssignableOperators";
import { type TOperator } from "@/types/models/Operator";

type TLineApi = {
  GetLineState: () => Promise<LineStateDTO | undefined>
  GetLine: () => Promise<TZone[] | undefined>
}

export const LineApi = (): TLineApi => {
  
  const GetLineState = async() => await GET<LineStateDTO>('Line/GetLineState');
  const GetLine = async() => await GET<TZone[]>('Line');

  return {
    GetLineState,
    GetLine
  };
}


