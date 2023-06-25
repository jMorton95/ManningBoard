import { FC, ReactNode, createContext } from "react";
import { TOperator } from "../types/models/Operator";
import { AuthService } from "../services/NewApiService";

type AuthState = {
  isAuthenticated: boolean;
  operator: TOperator | null;
  sessionID: number | null;
};

const initialState = {
  isAuthenticated: false,
  operator: null,
  sessionID: null,
};

export type TAuthContext = AuthState & {
  resume: () => void;
  login: (clockCardNumber: string) => Promise<void>;
  logout: () => Promise<void>;
};

type AuthProviderProps = {
  children: ReactNode;
};

export const AuthContext = createContext<TAuthContext>({
  ...initialState,
  resume: () => {},
  login: () => Promise.resolve(),
  logout: () => Promise.resolve(),
});

export const AuthProvider: FC<AuthProviderProps> = (props) => {
  const { children } = props;
  const { GetToken, ClockIn } = AuthService();

  return <AuthContext.Provider value={{}}>{children}</AuthContext.Provider>;
};
