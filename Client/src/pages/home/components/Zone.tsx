import { type TZone } from '../../../types/LineTypes'
import OpStation from './OpStation'

export default function Zone(props: TZone): JSX.Element {
  return (
    <div>
      <h2>{props.zoneName}</h2>
      <div className="zone row">
        {props.opStations.map((station) => (
          <OpStation key={station.id} {...station} />
        ))}
      </div>
    </div>
  )
}
