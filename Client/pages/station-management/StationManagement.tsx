import { useEffect, useState } from "react";
import StationMan from "../../src/components/station-management/StationMan";
import ZoneDropdown from "../../src/components/station-management/ZoneDropdown";
import { type TStation, type TZone } from "../../src/types/models/LineTypes";
import { PublicApiService } from "../../src/services/APIService";

const getSelectedZone = (zones: TZone[], station: TStation): string =>
  zones.find((x) => x.id === station.zoneID)?.zoneName ?? "No Zone Found";

export default function StationManagement(): JSX.Element {
  const { GetLine } = PublicApiService();
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
  }, [line]);

  //TODO: State Performance leak that causes whole section to re-render, probably due to the way data is being set here in state.
  //MEMOISE some stuff, at least the ZoneDropDown - Possibly even make a context to share state here.

  if (line == null) {
    return <div>Loading...</div>;
  }

  return (
    <section>
      <div className="">
        {line.map((zone) => (
          <ZoneDropdown
            key={zone.id}
            zone={zone}
            setSelectedStation={setSelectedStation}
          />
        ))}
      </div>
      {selectedStation != null && (
        <div className="">
          {line != null && selectedStation !== null && (
            <h2>{getSelectedZone(line, selectedStation)}</h2>
          )}
          {<StationMan selectedStation={selectedStation} />}
        </div>
      )}
    </section>
  );
}
