import { Popover, PopoverContent, PopoverTrigger } from "@/components/ui/popover";
import AssignableOperators, { type TAssignmentOptions } from "./AssignableOperators";
import { useAssignableOperators } from "@/hooks/useAssignableOperators";
import { SmallSpacer } from "@/components/ui/smallSpacer";

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
    return <SmallSpacer className="border w-20 cursor-not-allowed" aria-disabled={true} />;
  }

  return (
    <Popover>
      <PopoverTrigger
        className={`
          border border-gray-700 bg-white shadow-sm hover:bg-neutral-100 hover:text-neutral-900 dark:border-neutral-800
        dark:bg-neutral-950 dark:hover:bg-neutral-800 dark:hover:text-neutral-50  h-8 rounded-md px-3 text-xs flex items-center justify-center w-20
          font-semibold
        `}
      >
        {flavourText}
      </PopoverTrigger>
      <PopoverContent className="flex justify-between">
        <AssignableOperators stationId={stationId} assignType={assignType} assignableOperators={assignableOperators} />
      </PopoverContent>
    </Popover>
  );
}
