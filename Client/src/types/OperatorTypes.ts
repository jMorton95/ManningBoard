enum EStatusColor {
  "Green",
  "Yellow",
  "Red"
}

type TOperator = {
  clockCardNumber: number,
  operatorName: string,
  isAdministrator: boolean,
}

type TOperatorGrouped = {
  operator: TOperator,
  color: EStatusColor
}

export type { TOperatorGrouped, TOperator }
export { EStatusColor }
