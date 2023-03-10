import { SetStateAction } from "react";
import { Dropdown } from "react-bootstrap";
import { TOpStation, TZone } from "../../../types/LineTypes";

type TZoneDropdownProps = {
  zone: TZone,
  setSelectedOpStation: React.Dispatch<SetStateAction<TOpStation | undefined>>,
};

export default function ZoneDropdown(props: TZoneDropdownProps) {
  return (
    <Dropdown key={props.zone.id} className="pe-3">
      <Dropdown.Toggle className="btn btn-light bg-light-20 btn-border-square border-light-30">{props.zone.zoneName} </Dropdown.Toggle>
      <Dropdown.Menu>
        {props.zone.opStations.map((station) => (
          <Dropdown.Item key={station.id} onClick={() => props.setSelectedOpStation(station)}>
            {station.stationName}
          </Dropdown.Item>
        ))}
      </Dropdown.Menu>
    </Dropdown>
  );
}