import { LineStateContext } from "@/contexts/LineStateContext";
import { useContext } from "react";

export const useLineContext = () => useContext(LineStateContext);
