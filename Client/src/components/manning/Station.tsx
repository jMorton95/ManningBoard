import { useAuthContext } from "@/hooks/useAuthContext";
import { type StationStateDTO } from "@/types/dtos/LineState";

export default function Station(props: StationStateDTO): JSX.Element {
  const { station, operator } = props;
  const { currentOperator } = useAuthContext();

  return (
    <div className={"station col pt-2"}>
      <p>{station.stationName}</p>
      {operator != null ? <p>{operator.operatorName}</p> : <p>Unassigned</p>}
      {currentOperator?.isAdministrator == true && (
        <button
          className={"px-2 border-2 border-yellow-400 hover:bg-yellow-400"}
          type="button"
        >
          Click me!
        </button>
      )}
    </div>
  );
}
