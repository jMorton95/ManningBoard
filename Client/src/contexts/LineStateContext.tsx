import { type FC, type ReactNode, createContext } from 'react';
import { useLineState } from '../services/LineStateHook';

export type TLineStateContext = {
  invoke: () => Promise<void>
}

type LineStateProviderProps = { children: ReactNode }

const LineStateContext = createContext<TLineStateContext>({
  invoke: async () => { await Promise.resolve(); }
});

const LineStateContextProvider: FC<LineStateProviderProps> = (props) => {
  const { children } = props;
  const invoke = useLineState();
  return (
    <LineStateContext.Provider value={{ invoke }}>
      {children}
    </LineStateContext.Provider>
  );
};

export { LineStateContext, LineStateContextProvider };
