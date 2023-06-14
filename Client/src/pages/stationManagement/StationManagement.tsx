import { useEffect, useState } from 'react'
import { type TStation, type TZone } from '../../types/LineTypes'
import { AsyncFetchEndpointAndSetStateWithRetry } from '../../services/APIService'
import StationMan from './components/StationMan'
import ZoneDropdown from './components/ZoneDropdown'
import { type NonNegativeInteger } from '../../types/GenericTypes'
import { useSelector } from 'react-redux'
import { type RootState } from '../../types/ReduxTypes'

const getSelectedZone = (zones: TZone[], station: TStation): string => zones.find(x => x.id === station.zoneID)?.zoneName ?? 'No Zone Found'

export default function StationManagement(): JSX.Element {
  const [zones, setZones] = useState<TZone[]>()
  const [selectedStation, setSelectedStation] = useState<TStation>()
  const token = useSelector((state: RootState) => state.auth.token)

  useEffect(() => {
    if (zones == null) void AsyncFetchEndpointAndSetStateWithRetry<TZone[], NonNegativeInteger<3>>(setZones, 'Line', 3, token ?? '')
  })

  return (
    <section>
      <div className="stations-list d-flex gap-2 flex-row mb-5">
        {zones?.map((zone) => <ZoneDropdown key={zone.id} {...{ zone, setSelectedStation }} />)}
      </div>
      {(selectedStation != null) && token !== null &&
        <div className="station-editor">
          {(zones != null) && selectedStation !== null && <h2>{getSelectedZone(zones, selectedStation)}</h2>}
          {<StationMan selectedStation={selectedStation} token={token} />}
        </div>
      }
    </section>
  )
}
