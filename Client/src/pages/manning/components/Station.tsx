import { useAuthContext } from "@/hooks/useAuthContext";
import { type StationStateDTO } from "@/types/dtos/LineState";
import AssignablePopover from "./AssignablePopover";

export default function Station(props: StationStateDTO): JSX.Element {
  const { station, operator } = props;
  const { currentOperator } = useAuthContext();

  return (
    <div className={"col pt-2"}>
      <p>{station.stationName}</p>
      {operator != null ? <p>{operator.operatorName}</p> : <p>Unassigned</p>}
      {currentOperator?.isAdministrator && (
        <AssignablePopover stationId={station.id} />
      )}
    </div>
  );
}
