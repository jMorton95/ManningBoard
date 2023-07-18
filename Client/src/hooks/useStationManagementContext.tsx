import { StationManagementContext } from "@/contexts/StationManagementContext";
import { useContext } from "react";

export const useStationManagementContext = () => useContext(StationManagementContext);
