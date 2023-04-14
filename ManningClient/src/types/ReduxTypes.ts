import { TOperator } from "./OperatorTypes"

export type TCurrentUser = {
  currentOperator: TOperator,
  jsonWebToken: string
}

export type TAuthState = {
  token: string | null;
}

export type TCurrentUserState = {
  currentUser: TOperator | null
}

export interface RootState {
  auth: TAuthState;
  user: TCurrentUserState
}
