import { type LineStateDTO } from '@/types/dtos/LineState';
import { type HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { useEffect, useState } from 'react';

export type LineStateSetterAction = React.Dispatch<React.SetStateAction<LineStateDTO | null>>

export type LineStateHook = (setStateAction: LineStateSetterAction) => () => Promise<void>

export const useLineState: LineStateHook = (setStateAction: LineStateSetterAction) => {
  const [connection, setConnection] = useState<HubConnection | null>(null);

  const pushLineState = async(): Promise<void> => {
    try {
      if (connection !== null) {
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

      connection.start().then(() => {
          void pushLineState();
        })
        .catch((err: ErrorConstructor) => { console.error(err); });

      connection.on('LineStateUpdate', (lineState: LineStateDTO) => {
        setStateAction(lineState);
      });
    }

    return () => {
      if (connection !== null) {
        connection.off('LineStateUpdate');
      }
    };
  }, [connection]);

  return pushLineState;
};
