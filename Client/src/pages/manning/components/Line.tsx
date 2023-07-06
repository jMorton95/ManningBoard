import { useLineContext } from "@/hooks/useLineContext";
import Zone from "./Zone";

type LineProps = React.HTMLAttributes<HTMLDivElement>;

export default function Line({ ...props }: LineProps) {
  const { lineState } = useLineContext();

  if (!lineState) {
    return <div>Loading...</div>;
  }

  return lineState.map((zone) => (
    <Zone
      zoneStateDTO={zone}
      key={zone.zone.id}
      className={`h-[${100 / lineState.length}%]`}
    />
  ));
}
