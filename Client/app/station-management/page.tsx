export default function StationManagement(): JSX.Element {
  //const [selectedStation, setSelectedStation] = useState<TStation>();
  //const token = useSelector((state: RootState) => state.auth.token);

  //TODO: State Performance leak that causes whole section to re-render, probably due to the way data is being set here in state.
  //MEMOISE some stuff, at least the ZoneDropDown - Possibly even make a context to share state here.

  //if (lineState == null) {
  //return <div>Loading...</div>;
  //}

  // const getSelectedZone = (zones: ZoneStateDTO[], station: TStation): string =>
  //   zones.find((x) => x.zone.id === station.zoneID)?.zone.zoneName ??
  //   "No Zone Found";

  return (
    <section>
      <div className="stations-list d-flex mb-5 flex-row gap-2">
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
