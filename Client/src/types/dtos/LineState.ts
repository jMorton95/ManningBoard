import { type TStation, type TZone } from '../models/LineTypes';
import { type TOperator } from '../models/Operator';

type LineStateDTO = ZoneStateDTO[];

type ZoneStateDTO = {
  zone: TZone
  stationStateDTOs: StationStateDTO[]
}

type StationStateDTO = {
  station: TStation
  operator: TOperator | null
}

export type { LineStateDTO, ZoneStateDTO, StationStateDTO };
