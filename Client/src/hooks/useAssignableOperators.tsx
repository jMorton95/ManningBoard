import { LineManagementApi } from "@/api/LineManagementApi";
import { type TStationAssignableOperatorsDTO } from "@/types/dtos/StationAssignableOperators";
import { useState, useEffect } from "react";
import { useAuthContext } from "./useAuthContext";

const defaultState = {
  validOperators: [],
  trainingOperators: [],
};

export const useAssignableOperators: (
  stationId: number
) => TStationAssignableOperatorsDTO = (stationId: number) => {
  const { currentOperator, token } = useAuthContext();
  const [assignableOperators, setAssignableOperators] =
    useState<TStationAssignableOperatorsDTO>(defaultState);
  const LineApi =
    currentOperator && token ? LineManagementApi(currentOperator, token) : null;

  useEffect(() => {
    const getAssignableOperators = async () => {
      const assignable = await LineApi?.GetStationAssignableOperators(
        stationId
      );
      if (assignable) {
        setAssignableOperators(assignable);
      }
    };

    getAssignableOperators();
  }, []);

  return assignableOperators;
};
