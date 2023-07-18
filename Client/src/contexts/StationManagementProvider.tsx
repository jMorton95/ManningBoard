import { StationManagementContextProvider, type TStationManagementProviderProps } from "./StationManagementContext";

export const StationManagementProvider = ({ children }: TStationManagementProviderProps) => (
  <StationManagementContextProvider children={children} />
);
