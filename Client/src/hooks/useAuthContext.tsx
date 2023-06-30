import { AuthContext } from "@/auth/AuthContext";
import { useContext } from "react";

export const useAuthContext = () => useContext(AuthContext);
