import { FC, ReactNode, createContext, useEffect, useState } from "react";
import { AuthService } from "../services/NewApiService";
import {
  type AuthState,
  CurrentOperatorState,
} from "../redux/types/ReduxTypes";

const initialState: ReduxState = {
  token: null,
  currentOperator: null,
  sessionID: null,
};

type ReduxState = AuthState & CurrentOperatorState;

export type TAuthContext = ReduxState & {
  CLOCKIN: (clockCardNumber: string) => Promise<void>;
  CLOCKOUT: () => Promise<void>;
};

type AuthProviderProps = {
  children: ReactNode;
};

export const AuthContext = createContext<TAuthContext>({
  ...initialState,
  CLOCKIN: () => Promise.resolve(),
  CLOCKOUT: () => Promise.resolve(),
});

export const AuthProvider: FC<AuthProviderProps> = (props) => {
  const { children } = props;
  const [authState, setAuthState] = useState<ReduxState>(initialState);
  const authService = AuthService();

  useEffect(() => {
    const resume = async () => {
      const localToken = authService.GetToken();

      if (localToken) {
        let operatorDTO = await authService.GetCurrentlyClockedInOperator();

        setAuthState((currentState) => {
          return {
            ...currentState,
            token: localToken,
            currentOperator: operatorDTO.currentOperator,
            sessionID: operatorDTO.sessionID,
          };
        });
      }
    };

    resume();
  });

  const CLOCKIN = async (clockCardNumber: string) => {
    const operatorDTO = await authService.ClockIn(clockCardNumber);

    setAuthState((currentState) => {
      return {
        ...currentState,
        token: authService.GetToken(),
        currentOperator: operatorDTO.currentOperator,
        sessionID: operatorDTO.sessionID,
      };
    });
  };

  const CLOCKOUT = async () => {
    //TODO:
    //Implement
  };

  return (
    <AuthContext.Provider value={{ ...authState, CLOCKIN, CLOCKOUT }}>
      {children}
    </AuthContext.Provider>
  );
};
