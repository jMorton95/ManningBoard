import { useAuthContext } from "@/hooks/useAuthContext";
import { type StationStateDTO } from "@/types/dtos/LineState";
import AssignablePopover from "./AssignablePopover";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import AssignedOperator from "./AssignedOperator";
import BlankOperator from "./BlankOperator";

type StationProps = {
  stationState: StationStateDTO;
} & React.HTMLAttributes<HTMLDivElement>;

export default function Station({ stationState, ...props }: StationProps): JSX.Element {
  const { station, operatorAndAvatar, traineeAndAvatar } = stationState;
  const { currentOperator } = useAuthContext();

  return (
    <Card className={`${props.className}`}>
      <CardHeader>
        <CardTitle className="text-lg text-center font-semibold">{station.stationName}</CardTitle>
      </CardHeader>
      <CardContent>
        <div className={`flex ${operatorAndAvatar && traineeAndAvatar ? "justify-between" : "justify-center"}`}>
          {operatorAndAvatar ? <AssignedOperator dto={operatorAndAvatar} /> : <BlankOperator />}
          {traineeAndAvatar && <AssignedOperator dto={traineeAndAvatar} />}
        </div>
      </CardContent>
      <CardFooter>
        {currentOperator?.isAdministrator && (
          <>
            <AssignablePopover stationId={station.id} assignType="operator">
              Assign
            </AssignablePopover>
            <AssignablePopover stationId={station.id} assignType="training">
              Train
            </AssignablePopover>
          </>
        )}
      </CardFooter>
    </Card>
  );
}
