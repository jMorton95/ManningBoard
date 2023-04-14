enum EStatusColor {
  "Green",
  "Yellow",
  "Red"
}

type TOperator = {
  clockCardNumber: number,
  operatorName: string
}

type TOperatorGrouped = {
  operator: TOperator,
  color: EStatusColor
}

type TCurrentUser = {
  currentOperator: TOperator,
  jsonWebToken: string
}

export type { TOperatorGrouped, TOperator, TCurrentUser }
export { EStatusColor }
