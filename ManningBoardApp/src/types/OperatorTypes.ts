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

export type { TOperatorGrouped, TOperator }
export { EStatusColor }
