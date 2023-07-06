import { useAuthContext } from "@/hooks/useAuthContext";
import { type StationStateDTO } from "@/types/dtos/LineState";
import AssignablePopover from "./AssignablePopover";

type StationProps = {
  stationState: StationStateDTO;
} & React.HTMLAttributes<HTMLDivElement>;

export default function Station({
  stationState,
  ...props
}: StationProps): JSX.Element {
  const { station, operator } = stationState;
  const { currentOperator } = useAuthContext();

  return (
    <div className={`${props.className}`}>
      <p>{station.stationName}</p>
      {operator != null ? <p>{operator.operatorName}</p> : <p>Unassigned</p>}
      {currentOperator?.isAdministrator && (
        <AssignablePopover stationId={station.id} />
      )}
    </div>
  );
}
