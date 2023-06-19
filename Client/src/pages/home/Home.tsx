import { useEffect, useState } from 'react'
import { AsyncFetchEndpointAndSetState } from '../../services/APIService'
import Zone from './components/Zone'
import { type TZone } from '../../types/LineTypes'
import { type HubConnection, HubConnectionBuilder } from '@microsoft/signalr'

export default function Home(): JSX.Element {
  const [lineZones, setLineZones] = useState<TZone[]>()
  const [connection, setConnection] = useState<HubConnection | null>(null)

  function handleClick(): void {
    if (connection != null) {
      void doStuff(connection)
    }
  }

  async function doStuff(connection: HubConnection): Promise<void> {
    try {
      await connection.invoke('PushLineState')
    } catch (error: any) {
      console.error(error)
    }
  }

  useEffect(() => {
    const connection = new HubConnectionBuilder()
      .withUrl('https://localhost:7001/lineHub')
      .withAutomaticReconnect()
      .build()

    setConnection(connection)
  }, [])

  useEffect(() => {
    if (connection !== null) {
      connection.start()
        .then(() => { console.log('Connection Started') })
        .catch((err: ErrorConstructor) => { console.error(err) })

      connection.on('LineStateUpdate', (lineState: object) => {
        console.log(lineState)
      })
    }

    return () => {
      if (connection != null) {
        connection.off('LineStateUpdate')
      }
    }
  }, [connection])

  useEffect(() => {
    if (lineZones == null) {
      void AsyncFetchEndpointAndSetState<TZone[]>(setLineZones, 'Line')
    }
  }, [lineZones])

  return (
    <section className={'row'}>
      <button onClick={handleClick}>Click Me!</button>
      {lineZones?.map((zone) => <Zone {...zone} key={zone.id} />)}
    </section>
  )
}
