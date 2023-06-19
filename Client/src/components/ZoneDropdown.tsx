import { type SetStateAction } from 'react';
import { Dropdown } from 'react-bootstrap';
import { type TZone, type TStation } from '../types/models/LineTypes';

type TZoneDropdownProps = {
  zone: TZone
  setSelectedStation: React.Dispatch<SetStateAction<TStation | undefined>>
}

export default function ZoneDropdown(props: TZoneDropdownProps): JSX.Element {
  const { zone, setSelectedStation } = props;

  return (
    <Dropdown key={props.zone.id} className="pe-3">
      <Dropdown.Toggle className="btn btn-light bg-light-20 btn-border-square border-light-30">{props.zone.zoneName} </Dropdown.Toggle>
      <Dropdown.Menu>
        {zone.stations?.map((station) => (
          <Dropdown.Item key={station.id} onClick={() => { setSelectedStation(station); }}>
            {station.stationName}
          </Dropdown.Item>
        ))}
      </Dropdown.Menu>
    </Dropdown>
  );
}