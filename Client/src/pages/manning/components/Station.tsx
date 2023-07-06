import { useAuthContext } from "@/hooks/useAuthContext";
import { type StationStateDTO } from "@/types/dtos/LineState";
import AssignablePopover from "./AssignablePopover";
import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";

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
    <Card className={`${props.className}`}>
      <CardHeader>
        <CardTitle className="text-md">{station.stationName}</CardTitle>
      </CardHeader>
      <CardContent>
        {operator != null ? <p>{operator.operatorName}</p> : <p>Unassigned</p>}
      </CardContent>
      <CardFooter>
        {currentOperator?.isAdministrator && (
          <AssignablePopover stationId={station.id} />
        )}
      </CardFooter>
    </Card>
  );
}
