import { type FC, createContext, useEffect, useState } from "react";
import { ClockApi as AuthService } from "@/api/ClockApi";

import { type AuthProviderProps } from "./AuthenticationProvider";
import { type CurrentOperatorState, type AuthState } from "@/types/misc/StatefulTypes";
import { LineManagementApi, type TLineManagementApi } from "@/api/LineManagementApi";

const initialState: AuthenticationState = {
  token: null,
  currentOperator: null,
  sessionID: null,
};

const initialEditorModeState = false;

type AuthenticationState = AuthState & CurrentOperatorState;

type TAuthContext = AuthenticationState & {
  editorMode: boolean;
  CLOCKIN: (clockCardNumber: string) => Promise<void>;
  CLOCKOUT: () => Promise<void>;
  toggleEditorMode: () => void;
  Controller: TController;
};

type TController = {
  LineManagementAPI: ReturnType<TLineManagementApi> | null;
};

export const AuthContext = createContext<TAuthContext>({
  ...initialState,
  editorMode: initialEditorModeState,
  CLOCKIN: () => Promise.resolve(),
  CLOCKOUT: () => Promise.resolve(),
  toggleEditorMode: () => void {},
  Controller: {
    LineManagementAPI: null,
  },
});

export const AuthContextProvider: FC<AuthProviderProps> = (props) => {
  const [authState, setAuthState] = useState<AuthenticationState>(initialState);
  const [editorMode, setEditorMode] = useState<boolean>(initialEditorModeState);
  const authService = AuthService();

  const Controller: TController = {
    LineManagementAPI: authState.token ? LineManagementApi(authState.token) : null,
  };

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

  const toggleEditorMode = () => {
    if (authState.currentOperator?.isAdministrator) {
      setEditorMode(!editorMode);
    }
  };

  return (
    <AuthContext.Provider value={{ ...authState, editorMode, CLOCKIN, CLOCKOUT, toggleEditorMode, Controller }}>
      {props.children}
    </AuthContext.Provider>
  );
};
