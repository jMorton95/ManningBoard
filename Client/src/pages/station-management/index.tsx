import { type ZoneStateDTO } from '@/types/dtos/LineState';
import { type TStation } from '@/types/models/LineTypes';

export const getSelectedZone = (
  zones: ZoneStateDTO[],
  station: TStation,
): string =>
  zones.find((x) => x.zone.id === station.zoneID)?.zone.zoneName ??
  'No Zone Found';

export default function StationManagement(): JSX.Element {
  //const [selectedStation, setSelectedStation] = useState<TStation>();
  //const token = useSelector((state: RootState) => state.auth.token);

  //TODO: State Performance leak that causes whole section to re-render, probably due to the way data is being set here in state.
  //MEMOISE some stuff, at least the ZoneDropDown - Possibly even make a context to share state here.

  //if (lineState == null) {
  //return <div>Loading...</div>;
  //}

  return (
    <section>
      <div className="stations-list d-flex gap-2 flex-row mb-5">
        {/*{lineState.map((dto) => <ZoneDropdown key={dto.zone.id} zoneDTO={dto} setSelectedStation={setSelectedStation} />)} */}
      </div>
      {/*{(selectedStation != null) && token !== null &&
        <div className="station-editor">
          {(lineState != null) && selectedStation !== null && <h2>{getSelectedZone(lineState, selectedStation)}</h2>}
          {<StationMan selectedStation={selectedStation} token={token} />}
        </div>
      } */}
    </section>
  );
}
