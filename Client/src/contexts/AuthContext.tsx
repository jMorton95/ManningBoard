import {
  type FC,
  type ReactNode,
  createContext,
  useEffect,
  useState,
} from "react";
import { PrivateApiService as AuthService } from "../services/ApiService";
import {
  type AuthState,
  type CurrentOperatorState,
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

export const AuthContextProvider: FC<AuthProviderProps> = (props) => {
  const { children } = props;
  const [authState, setAuthState] = useState<ReduxState>(initialState);
  const authService = AuthService();

  useEffect(() => {
    const RESUME = async () => {
      const localToken = authService.GetToken();

      if (localToken && !authState.token) {
        const operatorDTO = await authService.GetCurrentlyClockedInOperator();

        if (!operatorDTO) {
          console.error("Tried to resume session, session no longer valid");
          return;
        }

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

    if (!authState.currentOperator) {
      void RESUME();
    }
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
    if (authState.sessionID) {
      await authService.ClockOut(authState.sessionID);
    } else {
      throw new Error("No active session to clock out.");
    }

    setAuthState((currentState) => {
      return {
        ...currentState,
        token: null,
        currentOperator: null,
        sessionID: null,
      };
    });
  };

  return (
    <AuthContext.Provider value={{ ...authState, CLOCKIN, CLOCKOUT }}>
      {children}
    </AuthContext.Provider>
  );
};
