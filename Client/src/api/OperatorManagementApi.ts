import { type TTrainingRequirement } from "@/types/models/LineTypes";
import { type TOperator } from "@/types/models/Operator";
import { GET } from "./BaseApi";

export type TOperatorManagementApiExport = (operator: TOperator, token: string) => TOperatorManagementApi | null

type TOperatorManagementApi = {
  GetOperatorByID: (operatorID: number) => Promise<TOperator | undefined>;
  GetAllOperators: () => Promise<TOperator[] | undefined>;
  GetTrainingForOperator: (operatorID: number) => Promise<TTrainingRequirement[] | undefined>;
  GetIncompleteTrainingForOperator: (operatorID: number) => Promise<TTrainingRequirement[] | undefined>;
}

export const OperatorManagementApi: TOperatorManagementApiExport = (operator: TOperator, token: string) => {

  if (!operator.isAdministrator || !token) {
    return null;
  }

  const GetOperatorByID = async(operatorID: number) => await GET<TOperator>(`OperatorManagement/${operatorID}`, token);

  const GetAllOperators = async() => await GET<TOperator[]>('OperatorManagement/GetAllOperators', token);

  const GetTrainingForOperator = async(operatorID: number) => GET<TTrainingRequirement[]>(`OperatorManagement/GetTrainingForOperator/${operatorID}`, token)

  const GetIncompleteTrainingForOperator = async(operatorID: number) => GET<TTrainingRequirement[]>(`OperatorManagement/GetIncompleteTrainingForOperator/${operatorID}`, token)

  return {GetOperatorByID, GetAllOperators, GetTrainingForOperator, GetIncompleteTrainingForOperator}
}