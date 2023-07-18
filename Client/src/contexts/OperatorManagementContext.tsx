import { type TOperator } from "@/types/models/Operator";
import { createContext, type ReactNode } from "react";

export type TOperatorManagementContextProvider = { children: ReactNode };

export type TOperatorManagementContext = {
  selectedOperator: TOperator | null;
};

const initialValues: TOperatorManagementContext = {
  selectedOperator: null,
};

export const OperatorManagementContext = createContext<TOperatorManagementContext>(initialValues);

export default function OperatorManagementContextProvider({ children }: TOperatorManagementContextProvider) {
  return <div>{children}</div>;
}
