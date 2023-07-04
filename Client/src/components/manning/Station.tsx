import { LineManagementApi } from "@/api/LineManagementApi";
import { useAuthContext } from "@/hooks/useAuthContext";
import { type StationStateDTO } from "@/types/dtos/LineState";
import { type TStationAssignableOperatorsDTO } from "@/types/dtos/StationAssignableOperators";
import { useState } from "react";

export default function Station(props: StationStateDTO): JSX.Element {
  const { station, operator } = props;
  const { currentOperator, token } = useAuthContext();
  const [assignableOperators, setAssignableOperators] =
    useState<TStationAssignableOperatorsDTO | null>(null);

  const LineApi =
    currentOperator && token ? LineManagementApi(currentOperator, token) : null;

  const handleButtonClick = async () => {
    const assignableOperatorsDTO = await LineApi?.GetStationAssignableOperators(
      station.id
    );

    if (assignableOperatorsDTO) {
      setAssignableOperators(assignableOperators);
    }
  };

  return (
    <div className={"station col pt-2"}>
      <p>{station.stationName}</p>
      {operator != null ? <p>{operator.operatorName}</p> : <p>Unassigned</p>}
      {currentOperator?.isAdministrator == true && (
        <button
          className={"px-2 border-2 border-yellow-400 hover:bg-yellow-400"}
          type="button"
          onClick={handleButtonClick}
        >
          Click me!
        </button>
      )}
    </div>
  );
}
