import { type LineStateDTO } from "@/types/dtos/LineState";
import { type TZone } from "@/types/models/LineTypes";
import { GET } from "./BaseApi";

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


