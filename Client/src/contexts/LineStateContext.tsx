import { type FC, type ReactNode, createContext, useState } from "react";
import { useLineState } from "../hooks/useLineState";
import { type LineStateDTO } from "../types/dtos/LineState";

export type TLineStateContext = {
  lineState: LineStateDTO | null;
  pushLineState: () => Promise<void>;
};

export type LineStateProviderProps = { children: ReactNode };

export const LineStateContext = createContext<TLineStateContext>({
  lineState: null,
  pushLineState: async () => {
    await Promise.resolve();
  },
});

export const LineStateContextProvider: FC<LineStateProviderProps> = (props) => {
  const [lineState, setLineState] = useState<LineStateDTO | null>(null);

  const pushLineState = useLineState(setLineState);

  return (
    <LineStateContext.Provider value={{ lineState, pushLineState }}>
      {props.children}
    </LineStateContext.Provider>
  );
};
