import { useContext } from "react";
import { AuthContext } from "../auth/AuthContext";

export const useAuthContext = () => useContext(AuthContext);
