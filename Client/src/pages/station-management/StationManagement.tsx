import { LineApi } from "@/api/LineApi";
import { type TZone, type TStation } from "@/types/models/LineTypes";
import { useEffect, useState } from "react";
import StationMan from "./components/StationMan";
import ZoneDropdown from "./components/ZoneDropdown";

const getSelectedZone = (zones: TZone[], station: TStation): string =>
  zones.find((x) => x.id === station.zoneID)?.zoneName ?? "No Zone Found";

export default function StationManagement(): JSX.Element {
  const { GetLine } = LineApi();
  const [selectedStation, setSelectedStation] = useState<TStation>();
  const [line, setLine] = useState<TZone[] | undefined>();

  useEffect(() => {
    const handleLineState = async () => {
      const line = await GetLine();
      setLine(line);
    };

    if (!line) {
      void handleLineState();
    }
  }, [line, GetLine]);

  //TODO: State Performance leak that causes whole section to re-render, probably due to the way data is being set here in state.
  //MEMOISE some stuff, at least the ZoneDropDown - Possibly even make a context to share state here.

  if (line == null) {
    return <div>Loading...</div>;
  }

  return (
    <section>
      <div className="">
        {line.map((zone) => (
          <ZoneDropdown key={zone.id} zone={zone} setSelectedStation={setSelectedStation} />
        ))}
      </div>
      {selectedStation != null && (
        <div className="">
          {line != null && selectedStation !== null && <h2>{getSelectedZone(line, selectedStation)}</h2>}
          {<StationMan selectedStation={selectedStation} />}
        </div>
      )}
    </section>
  );
}
