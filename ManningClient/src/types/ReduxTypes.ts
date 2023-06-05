import { TOperator } from "./OperatorTypes"

export type TCurrentUser = {
  currentOperator: TOperator,
  jsonWebToken: string,
  sessionID: number
}

export type TAuthState = {
  token: string | null;
}

export type TCurrentUserState = {
  currentUser: TOperator | null
  sessionID: number | null,
}

export interface RootState {
  auth: TAuthState;
  user: TCurrentUserState
}
