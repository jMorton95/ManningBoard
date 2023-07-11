import { Popover, PopoverContent, PopoverTrigger } from "@/components/ui/popover";
import AssignableOperators, { type TAssignmentOptions } from "./AssignableOperators";
import add from "@/icons/add.png";
import { Button } from "@/components/ui/buttonBase";
import { useAssignableOperators } from "@/hooks/useAssignableOperators";

type AssignablePopoverProps = {
  stationId: number;
  assignType: TAssignmentOptions;
} & React.ButtonHTMLAttributes<HTMLButtonElement>;

export default function AssignablePopover({ stationId, assignType }: AssignablePopoverProps) {
  const assignableOperators = useAssignableOperators(stationId);
  const flavourText = assignType === "operator" ? "Assign" : "Train";

  if (
    (assignType === "operator" && assignableOperators && assignableOperators.validOperators.length < 1) ||
    (assignType === "training" && assignableOperators && assignableOperators.trainingOperators.length < 1)
  ) {
    return <div className="h-8 rounded-md px-3"></div>;
  }

  return (
    <Popover>
      <PopoverTrigger>
        <Button variant={"outline"} size={"sm"}>
          <img src={add} width={14} alt={flavourText} />
          {flavourText}
        </Button>
      </PopoverTrigger>
      <PopoverContent className="flex justify-center">
        <AssignableOperators stationId={stationId} assignType={assignType} assignableOperators={assignableOperators} />
      </PopoverContent>
    </Popover>
  );
}
