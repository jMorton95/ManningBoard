import { type LineStateDTO } from '../../types/dtos/LineState';
import { type TOperator } from '../../types/models/Operator';

export type CurrentUser = {
  currentOperator: TOperator
  jsonWebToken: string
  sessionID: number
}

export type AuthState = {
  token: string | null
}

export type CurrentUserState = {
  currentUser: TOperator | null
  sessionID: number | null
}

export type LineState = {
  lineStateDTO: LineStateDTO | null
}

export type RootState = {
  auth: AuthState
  user: CurrentUserState
  lineState: LineState
}
