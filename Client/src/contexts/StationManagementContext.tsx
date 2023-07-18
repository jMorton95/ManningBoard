import { type TZone, type TStation } from "@/types/models/LineTypes";
import { type FC, type ReactNode, createContext, useState } from "react";

const initialValues: TStationManagementContext = {
  selectedStation: null,
  handleSelectedStationUpdate: (_station: TStation) => void {},
  line: null,
  handleLineUpdate: (_line: TZone[]) => void {},
};

type TStationManagementContext = {
  selectedStation: TStation | null;
  handleSelectedStationUpdate: (station: TStation) => void;
  line: TZone[] | null;
  handleLineUpdate: (_line: TZone[]) => void;
};

export const StationManagementContext = createContext<TStationManagementContext>(initialValues);

export type TStationManagementProviderProps = {
  children: ReactNode;
};

export const StationManagementContextProvider: FC<TStationManagementProviderProps> = ({ children }) => {
  const [selectedStation, setSelectedStation] = useState<TStation | null>(null);
  const [line, setLine] = useState<TZone[] | null>(null);

  const handleSelectedStationUpdate = (station: TStation) => setSelectedStation(station);
  const handleLineUpdate = (line: TZone[]) => setLine(line);

  return (
    <StationManagementContext.Provider
      value={{
        selectedStation,
        handleSelectedStationUpdate,
        line,
        handleLineUpdate,
      }}
    >
      {children}
    </StationManagementContext.Provider>
  );
};
