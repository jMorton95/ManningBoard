import { useAuthContext } from "@/hooks/useAuthContext";
import { type StationStateDTO } from "@/types/dtos/LineState";
import AssignablePopover from "./AssignablePopover";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import AssignedOperator from "./AssignedOperator";
import BlankOperator from "./BlankOperator";
import { SmallSpacer } from "@/components/ui/smallSpacer";
import { type ClassNameProp } from "@/types/misc/HelperTypes";

type StationProps = {
  stationState: StationStateDTO;
} & ClassNameProp;

export default function Station({ stationState, ...props }: StationProps): JSX.Element {
  const { station, operatorAndAvatar, traineeAndAvatar } = stationState;
  const { currentOperator } = useAuthContext();

  return (
    <Card
      className={`${props.className ?? ""} rounded-sm border-custom-main-200 shadow-custom-main-400 drop-shadow-sm`}
    >
      <CardHeader className="py-0">
        <CardTitle className="text-lg text-center font-semibold">{station.stationName}</CardTitle>
      </CardHeader>
      <CardContent>
        <div className={`flex gap-1`}>
          {operatorAndAvatar ? (
            <AssignedOperator dto={operatorAndAvatar} children={"Operator"} />
          ) : (
            <BlankOperator children={"Operator"} className="opacity-20" />
          )}
          {traineeAndAvatar ? (
            <AssignedOperator dto={traineeAndAvatar} children={"Trainee"} />
          ) : (
            <BlankOperator children={"Trainee"} className="opacity-20" />
          )}
        </div>
      </CardContent>
      <CardFooter className="flex justify-around">
        {currentOperator?.isAdministrator ? (
          <>
            <AssignablePopover stationId={station.id} assignType="operator">
              Assign
            </AssignablePopover>
            <AssignablePopover stationId={station.id} assignType="training">
              Train
            </AssignablePopover>
          </>
        ) : (
          <SmallSpacer />
        )}
      </CardFooter>
    </Card>
  );
}
