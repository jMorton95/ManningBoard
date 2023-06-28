import { useContext } from "react";
import { LineStateContext } from "../contexts/LineStateContext";

export const useLineContext = () => useContext(LineStateContext);
