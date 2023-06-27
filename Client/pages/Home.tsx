import { useSelector } from "react-redux";
import { type RootState } from "../src/redux/types/ReduxTypes";
import Zone from "../src/components/home/Zone";
import { LineStateContextProvider } from "../src/contexts/LineStateContext";

export default function Home(): JSX.Element {
  const lineState = useSelector(
    (state: RootState) => state.lineState.lineStateDTO
  );

  if (lineState == null) {
    return <div>Loading...</div>;
  }

  return (
    <LineStateContextProvider>
      <section className={"row"}>
        {lineState?.map((zone) => (
          <Zone zoneStateDTO={zone} key={zone.zone.id} />
        ))}
      </section>
    </LineStateContextProvider>
  );
}
