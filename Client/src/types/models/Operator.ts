import { type Base } from './BaseType';

type TOperator = Base & {
  clockCardNumber: number
  operatorName: string
  isAdministrator: boolean
}

export type { TOperator };
