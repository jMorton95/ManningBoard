import { LineManagementApi } from "@/api/LineManagementApi";
import { LoadingSpinner } from "@/components/LoadingSpinner";
import { useAuthContext } from "@/hooks/useAuthContext";
import { useLineContext } from "@/hooks/useLineContext";
import { type TAssignableOperators } from "@/types/dtos/StationAssignableOperators";
import { useState, useEffect } from "react";

type AssignableOperatorsProps = {
  stationId: number;
};

export default function AssignableOperators({
  stationId,
}: AssignableOperatorsProps) {
  const { currentOperator, token } = useAuthContext();
  const [assignableOperators, setAssignableOperators] = useState<
    TAssignableOperators | undefined
  >();
  const LineApi =
    currentOperator && token ? LineManagementApi(currentOperator, token) : null;
  const { pushLineState } = useLineContext();

  useEffect(() => {
    const getAssignableOperators = async () => {
      const assignable = await LineApi?.GetStationAssignableOperators(
        stationId
      );
      setAssignableOperators(assignable);
    };

    getAssignableOperators();
  }, []);

  const addAssignableOperator = async (
    operatorID: number,
    stationID: number
  ) => {
    const resp = await LineApi?.AddOperatorToStation(operatorID, stationID);
    if (resp) {
      //TODO: Add Toast.
      pushLineState();
      console.log(`Added operator ${operatorID} to station ${stationID}`);
    }
  };

  if (!assignableOperators) return <LoadingSpinner />;

  return (
    <div className=" text-red-500">
      Assignable:
      {assignableOperators.validOperators.map((x) => (
        <p
          key={x.id}
          onClick={() => {
            addAssignableOperator(x.id, stationId);
          }}
        >
          {x.operatorName}
        </p>
      ))}
    </div>
  );
}
