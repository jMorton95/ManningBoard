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
    return null;
  }

  return (
    <Popover>
      <PopoverTrigger
        className={`border border-neutral-200 bg-white shadow-sm hover:bg-neutral-100 hover:text-neutral-900 dark:border-neutral-800
        dark:bg-neutral-950 dark:hover:bg-neutral-800 dark:hover:text-neutral-50  h-8 rounded-md px-3 text-xs`}
      >
        {/* <Button variant={"outline"} size={"sm"}> */}
        <img src={add} width={14} alt={flavourText} />
        {flavourText}
        {/* </Button> */}
      </PopoverTrigger>
      <PopoverContent className="flex justify-center">
        <AssignableOperators stationId={stationId} assignType={assignType} assignableOperators={assignableOperators} />
      </PopoverContent>
    </Popover>
  );
}
