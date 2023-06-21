import { type SetStateAction } from 'react';
import { Dropdown } from 'react-bootstrap';
import { type TStation } from '../types/models/LineTypes';
import { type ZoneStateDTO } from '../types/dtos/LineState';

type TZoneDropdownProps = {
  zoneDTO: ZoneStateDTO
  setSelectedStation: React.Dispatch<SetStateAction<TStation | undefined>>
}

export default function ZoneDropdown(props: TZoneDropdownProps): JSX.Element {
  const { zoneDTO, setSelectedStation } = props;

  return (
    <Dropdown key={zoneDTO.zone.id} className="pe-3">
      <Dropdown.Toggle className="btn btn-light bg-light-20 btn-border-square border-light-30">{zoneDTO.zone.zoneName} </Dropdown.Toggle>
      <Dropdown.Menu>
        {zoneDTO.stationStateDTOs?.map((dto) => (
          <Dropdown.Item key={dto.station.id} onClick={() => { setSelectedStation(dto.station); }}>
            {dto.station.stationName}
          </Dropdown.Item>
        ))}
      </Dropdown.Menu>
    </Dropdown>
  );
}
