import { useStationManagementContext } from "@/hooks/useStationManagementContext";
import { type TZone } from "@/types/models/LineTypes";
import { Dropdown } from "react-bootstrap";

type TZoneDropdownProps = {
  zone: TZone;
};

export default function ZoneDropdown({ zone }: TZoneDropdownProps): JSX.Element {
  const { handleSelectedStationUpdate } = useStationManagementContext();

  return (
    <Dropdown key={zone.id} className="pe-3">
      <Dropdown.Toggle className="btn btn-light bg-light-20 btn-border-square border-light-30">
        {zone.zoneName}
      </Dropdown.Toggle>
      <Dropdown.Menu>
        {zone.stations !== null &&
          zone.stations.map((station) => (
            <Dropdown.Item
              key={station.id}
              onClick={() => {
                handleSelectedStationUpdate(station);
              }}
            >
              {station.stationName}
            </Dropdown.Item>
          ))}
      </Dropdown.Menu>
    </Dropdown>
  );
}
