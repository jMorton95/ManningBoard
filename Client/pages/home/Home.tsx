import { useSelector } from "react-redux";
import { RootState } from "../../src/redux/types/ReduxTypes";
import Zone from "../../src/components/Zone";

export default function Home(): JSX.Element {
  const lineState = useSelector(
    (state: RootState) => state.lineState.lineStateDTO
  );

  if (lineState == null) {
    return <div>Loading...</div>;
  }

  return (
    <section className={"row"}>
      {lineState?.map((zone) => (
        <Zone zoneStateDTO={zone} key={zone.zone.id} />
      ))}
    </section>
  );
}
