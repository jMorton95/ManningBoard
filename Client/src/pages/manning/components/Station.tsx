import { useAuthContext } from "@/hooks/useAuthContext";
import { type StationStateDTO } from "@/types/dtos/LineState";
import { useState } from "react";
import AssignableOperators from "./AssignableOperators";

export default function Station(props: StationStateDTO): JSX.Element {
  const { station, operator } = props;
  const { currentOperator } = useAuthContext();
  const [viewAssignableOperators, setViewAssignableOperators] =
    useState<boolean>(false);

  const handleButtonClick = () =>
    setViewAssignableOperators(!viewAssignableOperators);

  return (
    <div className={"col pt-2"}>
      <p>{station.stationName}</p>
      {operator != null ? <p>{operator.operatorName}</p> : <p>Unassigned</p>}
      {currentOperator?.isAdministrator && (
        <button
          className={"px-2 border-2 border-yellow-400 hover:bg-yellow-400"}
          type="button"
          onClick={handleButtonClick}
        >
          Click me!
        </button>
      )}
      {viewAssignableOperators && (
        <AssignableOperators stationId={station.id} />
      )}
    </div>
  );
}
