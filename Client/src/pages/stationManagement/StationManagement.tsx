import { useEffect, useState } from 'react'
import { type TOpStation, type TZone } from '../../types/LineTypes'
import { AsyncFetchEndpointAndSetStateWithRetry } from '../../services/APIService'
import OpStationMan from './components/OpStationMan'
import ZoneDropdown from './components/ZoneDropdown'
import { type NonNegativeInteger } from '../../types/GenericTypes'
import { useSelector } from 'react-redux'
import { type RootState } from '../../types/ReduxTypes'

const getSelectedZone = (zones: TZone[], opstation: TOpStation): string => zones.find(x => x.id === opstation.zoneID)?.zoneName ?? 'No Zone Found'

export default function StationManagement(): JSX.Element {
  const [zones, setZones] = useState<TZone[]>()
  const [selectedOpStation, setSelectedOpStation] = useState<TOpStation>()
  const token = useSelector((state: RootState) => state.auth.token)

  useEffect(() => {
    if (zones == null) void AsyncFetchEndpointAndSetStateWithRetry<TZone[], NonNegativeInteger<3>>(setZones, 'Line', 3, token ?? '')
  })

  return (
    <section>
      <div className="stations-list d-flex gap-2 flex-row mb-5">
        {zones?.map((zone) => <ZoneDropdown key={zone.id} {...{ zone, setSelectedOpStation }} />)}
      </div>
      {(selectedOpStation != null) && token !== null &&
        <div className="station-editor">
          {(zones != null) && selectedOpStation !== null && <h2>{getSelectedZone(zones, selectedOpStation)}</h2>}
          {<OpStationMan selectedStation={selectedOpStation} token={token} />}
        </div>
      }
    </section>
  )
}
