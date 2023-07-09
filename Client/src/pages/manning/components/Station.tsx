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
import { binaryStringToImgSrc } from "@/utilities/Helpers";
import InlineAvatar from "@/components/InlineAvatar";
import blankAvatar from "@/icons/blankavatar.png";

type StationProps = {
  stationState: StationStateDTO;
} & React.HTMLAttributes<HTMLDivElement>;

export default function Station({
  stationState,
  ...props
}: StationProps): JSX.Element {
  const { station, operatorAndAvatar } = stationState;
  const { currentOperator } = useAuthContext();

  return (
    <Card className={`${props.className}`}>
      <CardHeader>
        <CardTitle className="text-lg font-semibold">
          {station.stationName}
        </CardTitle>
      </CardHeader>
      <CardContent>
        {operatorAndAvatar != null ? (
          <>
            <p>{operatorAndAvatar.operator.operatorName}</p>
            <InlineAvatar
              width={54}
              title={`${operatorAndAvatar.operator.operatorName} ${operatorAndAvatar.avatar.fileName}`}
              src={binaryStringToImgSrc(operatorAndAvatar.avatar.fileContent)}
              content={operatorAndAvatar.avatar.contentType}
            />
          </>
        ) : (
          <>
            <p className="font-semibold">Empty</p>
            <InlineAvatar
              width={64}
              title={`Empty Avatar`}
              src={blankAvatar}
              className=" opacity-25"
            />
          </>
        )}
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
