import { LoadingSpinner } from "@/components/LoadingSpinner";
import { useAuthContext } from "@/hooks/useAuthContext";
import { useLineContext } from "@/hooks/useLineContext";
import { type TStationAssignableOperatorsDTO } from "@/types/dtos/StationAssignableOperators";

export type TAssignmentOptions = "operator" | "training";

type AssignableOperatorsProps = {
  stationId: number;
  assignType: TAssignmentOptions;
  assignableOperators: TStationAssignableOperatorsDTO;
};

export default function AssignableOperators({ stationId, assignType, assignableOperators }: AssignableOperatorsProps) {
  const { pushLineState } = useLineContext();
  const { Controller } = useAuthContext();

  if (!assignableOperators) return <LoadingSpinner />;

  const addAssignableOperator = async (operatorID: number, stationID: number, isTrainee: boolean) => {
    const resp =
      Controller.private?.LineManagementAPI !== null
        ? await Controller.private?.LineManagementAPI?.AddOperatorToStation(operatorID, stationID, isTrainee)
        : null;

    if (resp) {
      //TODO: Add Toast.
      void pushLineState();
    }
  };

  return (
    <div className=" text-red-500">
      {assignType === "operator" ? (
        <>
          {assignableOperators.validOperators.map((x) => (
            <p
              key={x.id}
              onClick={() => {
                void addAssignableOperator(x.id, stationId, false);
              }}
            >
              {x.operatorName}
            </p>
          ))}
        </>
      ) : (
        <>
          {assignableOperators.trainingOperators.map((x) => (
            <p
              key={x.id}
              onClick={() => {
                {
                  /**Needs to be moved to AddTrainingOperator once created */
                }
                void addAssignableOperator(x.id, stationId, true);
              }}
            >
              {x.operatorName}
            </p>
          ))}
        </>
      )}
    </div>
  );
}
