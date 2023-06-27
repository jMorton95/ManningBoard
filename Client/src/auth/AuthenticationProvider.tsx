import { type ReactNode } from "react";
import { AuthContextProvider } from "./AuthContext";

export type AuthProviderProps = {
  children: ReactNode;
};

export const AuthenticationProvider = ({ children }: AuthProviderProps) => (
  <AuthContextProvider children={children} />
);
