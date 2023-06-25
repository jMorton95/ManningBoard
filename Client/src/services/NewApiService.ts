import { type LineStateDTO } from '../types/dtos/LineState';
import { type CurrentOperator } from '../redux/types/ReduxTypes';
import { API_ENDPOINTS } from '../config/config';
import { TZone } from '../types/models/LineTypes';

type TApiService = {
  GetLineState: () => Promise<LineStateDTO | undefined>
  GetClockedOperator: (clockNumber: string) => Promise<CurrentOperator | undefined>
  GetLine: () => Promise<TZone[] | undefined>
}

const GetResponseBase = async(endpoint: string): Promise<Response> => {
  return await fetch(`${API_ENDPOINTS.base}/${endpoint}`, {
    method: 'GET',
    credentials: 'include',
    headers: {
      "Content-Type": "application/json",
    },
  });
};

function ApiService(): TApiService {
  async function GET<T>(endpoint: string): Promise<T | undefined> {
    try {
      const res = await GetResponseBase(endpoint);

      if (!res.ok) {
        throw new Error('Response was not OK');
      }

      return await res.json().then((data) => {
        return data as T;
      });
    } catch (error) {
      console.error(error);
    }
  }

  const GetLineState = async() => await GET<LineStateDTO>('Line/GetLineState');
  const GetClockedOperator = async(clockNumber: string) => await GET<CurrentOperator>(`Clock/${clockNumber}`);
  const GetLine = async() => await GET<TZone[]>('Line');

  return {
    GetLineState,
    GetClockedOperator,
    GetLine
  };
}

type TAuthService = {
  ClockIn: (clockCardNumber: string) => Promise<CurrentOperator>
  GetToken(): string
  GetCurrentlyClockedInOperator: () => Promise<CurrentOperator>
}

function AuthService(): TAuthService {

  function setToken(res: Response){
    try {
      const jwt = res.headers.get('Jwt');
      if (jwt){
        localStorage.setItem('Jwt', jwt);
      }
    }
    catch (error) {
      console.error(error);
    }
  }

  function GetToken(): string {
    const jwt = localStorage.getItem('Jwt');
    if (!jwt) {
      throw new Error("No Jwt found in localStorage");
    }
    return jwt ?? ''
  }

  async function ClockIn(clockCardNumber: string) {
    const res = await GetResponseBase(`Clock/${clockCardNumber}`);
    if (!res.ok) {
      throw new Error('Response was not OK');
    }

    setToken(res)

    return await res.json().then((data) => {
      return data as CurrentOperator;
    });
  }

  async function GetCurrentlyClockedInOperator() {
    const res = await GetResponseBase(`Clock/GetOperatorFromJWT/${GetToken()}`);

    if (!res.ok) {
      throw new Error('Response was not OK');
    }

    return await res.json().then((data) => {
      return data as CurrentOperator;
    });
  }

  return {
    ClockIn,
    GetToken,
    GetCurrentlyClockedInOperator
  };
}

export { ApiService, AuthService };
