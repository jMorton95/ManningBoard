import { type TStationAssignableOperatorsDTO } from "@/types/dtos/StationAssignableOperators";
import { useState, useEffect, useCallback } from "react";
import { useAuthContext } from "./useAuthContext";

const defaultState = {
  validOperators: [],
  trainingOperators: [],
};

export const useAssignableOperators: (stationId: number) => TStationAssignableOperatorsDTO = (stationId: number) => {
  const [assignableOperators, setAssignableOperators] = useState<TStationAssignableOperatorsDTO>(defaultState);
  const { Controller } = useAuthContext();

  const getAssignableOperators = useCallback( async () => {
    const assignable = await Controller.LineManagementAPI?.GetStationAssignableOperators(stationId);
    if (assignable) {
      setAssignableOperators(assignable);
    }
  },[Controller.LineManagementAPI, stationId]);

  useEffect(() => {
    void getAssignableOperators();
  }, [getAssignableOperators]);

  return assignableOperators;
};
