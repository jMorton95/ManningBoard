import { useLineContext } from "@/hooks/useLineContext";
import Zone from "./Zone";
import { LoadingSpinner } from "@/components/LoadingSpinner";
import Absences from "./Absences";

export default function Line() {
  const { lineState } = useLineContext();

  if (!lineState) {
    return <LoadingSpinner />;
  }

  return (
    <>
      {lineState.map((zone) => (
        <Zone
          zoneStateDTO={zone}
          key={zone.zone.id}
          className={`h-[${100 / (lineState.length + 1)}%]`}
        />
      ))}

      <Absences
        className={`h-[${
          100 / (lineState.length + 1)
        }%] bg-custom-main-200 px-6`}
      />
    </>
  );
}
