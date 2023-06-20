import { type HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { useEffect, useState } from 'react';
import { useDispatch } from 'react-redux';
import { setLineState } from '../redux/slices/LineStateSlice';
import { type LineStateDTO } from '../types/dtos/LineState';

export type LineStateHook = () => Promise<void>

export const useLineState = (): LineStateHook => {
  const [connection, setConnection] = useState<HubConnection | null>(null);
  const dispatch = useDispatch();

  const invoke = async(): Promise<void> => {
    try {
      if (connection != null) {
        await connection.invoke('PushLineState');
      }
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    const connection = new HubConnectionBuilder()
      .withUrl(`${import.meta.env.VITE_BASE_API_URL}/lineHub`)
      .withAutomaticReconnect()
      .build();

    setConnection(connection);
  }, []);

  useEffect(() => {
    if (connection !== null) {
      connection.start()
        .then(() => {
          console.log('Connection Started');
          void invoke();
        })
        .catch((err: ErrorConstructor) => { console.error(err); });

      connection.on('LineStateUpdate', (lineState: LineStateDTO) => {
        console.log('Received LineStateUpdate:', lineState);
        dispatch(setLineState(lineState));
      });
    }

    return () => {
      if (connection != null) {
        connection.off('LineStateUpdate');
      }
    };
  }, [connection]);

  return invoke;
};
