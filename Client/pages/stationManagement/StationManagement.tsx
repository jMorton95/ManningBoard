import { useEffect, useState } from "react";
import StationMan from "../../src/components/StationMan";
import ZoneDropdown from "../../src/components/ZoneDropdown";
import { TStation, TZone } from "../../src/types/models/LineTypes";
import { ApiService } from "../../src/services/ApiService";

const getSelectedZone = (zones: TZone[], station: TStation): string =>
  zones.find((x) => x.id === station.zoneID)?.zoneName ?? "No Zone Found";

export default function StationManagement(): JSX.Element {
  const { GetLine } = ApiService();
  const [selectedStation, setSelectedStation] = useState<TStation>();
  const [line, setLine] = useState<TZone[] | undefined>();

  useEffect(() => {
    if (!line) {
      handleLineState();
    }
  }, [line]);

  const handleLineState = async () => {
    const line = await GetLine();
    setLine(line);
  };

  //TODO: State Performance leak that causes whole section to re-render, probably due to the way data is being set here in state.
  //MEMOISE some stuff, at least the ZoneDropDown - Possibly even make a context to share state here.

  if (line == null) {
    return <div>Loading...</div>;
  }

  return (
    <section>
      <div className="stations-list d-flex gap-2 flex-row mb-5">
        {line.map((zone) => (
          <ZoneDropdown
            key={zone.id}
            zone={zone}
            setSelectedStation={setSelectedStation}
          />
        ))}
      </div>
      {selectedStation != null && (
        <div className="station-editor">
          {line != null && selectedStation !== null && (
            <h2>{getSelectedZone(line, selectedStation)}</h2>
          )}
          {<StationMan selectedStation={selectedStation} />}
        </div>
      )}
    </section>
  );
}
