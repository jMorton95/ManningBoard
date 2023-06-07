import { useEffect, useState } from 'react'
import { AsyncFetchEndpointAndSetState } from '../../services/APIService'
import Zone from './components/Zone'
import { type TZone } from '../../types/LineTypes'

export default function Home(): JSX.Element {
  const [lineZones, setLineZones] = useState<TZone[]>()

  useEffect(() => {
    if (lineZones == null) {
      void AsyncFetchEndpointAndSetState<TZone[]>(setLineZones, 'Line')
    }
  }, [lineZones])

  return (
    <section className={'row'}>
      {lineZones?.map((zone) => <Zone {...zone} key={zone.id} />)}
    </section>
  )
}
