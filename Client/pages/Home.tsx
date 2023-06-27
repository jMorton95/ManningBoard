import { useDispatch, useSelector } from "react-redux";
import { type RootState } from "../src/redux/types/ReduxTypes";
import { LineStateContextProvider } from "../src/contexts/LineStateContext";
import Zone from "../src/components/home/Zone";
import { PublicApiService } from "../src/services/ApiService";
import { setLineState } from "../src/redux/slices/LineStateSlice";
import { useEffect } from "react";

export default function Home(): JSX.Element {
  const apiService = PublicApiService();
  const lineState = useSelector(
    (state: RootState) => state.lineState.lineStateDTO
  );
  const dispatch = useDispatch();

  useEffect(() => {
    const getInitialLineState = async () => {
      const initialLineState = await apiService.GetLineState();

      if (initialLineState) {
        dispatch(setLineState(initialLineState));
      }
    };

    getInitialLineState();
  }, []);

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
