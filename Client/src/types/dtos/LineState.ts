import { type TStation, type TZone } from "../models/LineTypes";
import { type TOperator } from "../models/Operator";
import { type TAvatar } from "./AvatarDTO";

type LineStateDTO = ZoneStateDTO[];

type ZoneStateDTO = {
  zone: TZone
  stationStateDTOs: StationStateDTO[]
}

type StationStateDTO = {
  station: TStation;
  operatorAndAvatar: OperatorAndAvatarDTO | null;
  traineeAndAvatar?: OperatorAndAvatarDTO  | null;
}

type OperatorAndAvatarDTO = {
  avatar: TAvatar;
  operator: TOperator;
}

export type { LineStateDTO, ZoneStateDTO, StationStateDTO, OperatorAndAvatarDTO };
