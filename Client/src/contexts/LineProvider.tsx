import {
  LineStateContextProvider,
  type LineStateProviderProps,
} from "./LineStateContext";

export const LineProvider = ({ children }: LineStateProviderProps) => (
  <LineStateContextProvider children={children} />
);
