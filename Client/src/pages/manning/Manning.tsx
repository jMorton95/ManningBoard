import { useLineContext } from "@/hooks/useLineContext";
import { LoadingSpinner } from "@/components/LoadingSpinner";
import Absences from "./components/Absences";
import Zone from "./components/Zone";

export default function Manning(): JSX.Element {
  const { lineState } = useLineContext();

  if (!lineState) {
    return <LoadingSpinner />;
  }
  return (
    <section className={"text-slate-900 container-fluid flex flex-col justify-between h-full"}>
      <>
        {lineState.map((zone) => (
          <Zone zoneStateDTO={zone} key={zone.zone.id} className={`h-1/${lineState.length}`} />
        ))}

        <Absences className={`h-20 bg-custom-main-200 px-6`} />
      </>
    </section>
  );
}
