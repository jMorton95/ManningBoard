import { type SetStateAction } from 'react'
import { Dropdown } from 'react-bootstrap'
import { type TStation, type TZone } from '../../../types/LineTypes'

interface TZoneDropdownProps {
  zone: TZone
  setSelectedStation: React.Dispatch<SetStateAction<TStation | undefined>>
}

export default function ZoneDropdown(props: TZoneDropdownProps): JSX.Element {
  return (
    <Dropdown key={props.zone.id} className="pe-3">
      <Dropdown.Toggle className="btn btn-light bg-light-20 btn-border-square border-light-30">{props.zone.zoneName} </Dropdown.Toggle>
      <Dropdown.Menu>
        {props.zone.stations.map((station) => (
          <Dropdown.Item key={station.id} onClick={() => { props.setSelectedStation(station) }}>
            {station.stationName}
          </Dropdown.Item>
        ))}
      </Dropdown.Menu>
    </Dropdown>
  )
}
