import { type TOperator } from "../models/Operator";

export type TStationAssignableOperatorsDTO = {
  validOperators: TOperator[];
  trainingOperators: TOperator[];
}