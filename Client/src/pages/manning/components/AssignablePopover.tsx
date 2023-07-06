import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import AssignableOperators from "./AssignableOperators";

type AssignablePopoverProps = {
  stationId: number;
};

export default function AssignablePopover({
  stationId,
}: AssignablePopoverProps) {
  return (
    <Popover>
      <PopoverTrigger>Open</PopoverTrigger>
      <PopoverContent className="flex justify-center">
        <AssignableOperators stationId={stationId} />
      </PopoverContent>
    </Popover>
  );
}
