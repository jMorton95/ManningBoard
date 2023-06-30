import { type LineStateDTO } from "@/types/dtos/LineState"
import { type TOperator } from "@/types/models/Operator"

export type CurrentOperator = {
  currentOperator: TOperator
  sessionID: number
}

export type AuthState = {
  token: string | null
}

export type CurrentOperatorState = {
  currentOperator: TOperator | null
  sessionID: number | null
}

export type LineState = {
  lineStateDTO: LineStateDTO | null
}

// export type RootState = {
//   auth: AuthState
//   user: CurrentOperatorState
//   lineState: LineState
// }
