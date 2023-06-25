import { API_ENDPOINTS } from '../../../../../config';
import { type LineStateDTO } from '../types/dtos/LineState';
import { type CurrentUser } from '../redux/types/ReduxTypes';

type TApiService = {
  GET: <T> (username: string, _cacheOption?: RequestCache) => Promise<T | undefined>
  GetLineState: (_cacheOption?: RequestCache) => Promise<LineStateDTO | undefined>
  GetClockedOperator: (clockNumber: string, _cacheOption?: RequestCache) => Promise<CurrentUser | undefined>
}

const ResponseBase = async(endpoint: string, _cacheOption?: RequestCache): Promise<Response> => {
  return await fetch(`${API_ENDPOINTS.base}${endpoint}`, { cache: `${_cacheOption ?? 'force-cache'}` });
};

function ApiService(): TApiService {
  async function GET<T>(endpoint: string, _cacheOption?: RequestCache): Promise<T | undefined> {
    try {
      const res = await ResponseBase(endpoint, _cacheOption);

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

  const GetLineState = async(_cacheOption?: RequestCache) => await GET<LineStateDTO>('Line/GetLineState', _cacheOption);
  const GetClockedOperator = async(clockNumber: string, _cacheOption?: RequestCache) => await GET<CurrentUser>(`Clock/${clockNumber}`, _cacheOption);

  return {
    GET,
    GetLineState,
    GetClockedOperator
  };
}

type TAuthService = {
  ClockIn: (clockCardNumber: string) => Promise<Response>
}

function AuthService(): TAuthService {
  async function ClockIn(clockCardNumber: string) {
    const res = await ResponseBase(`Clock/${clockCardNumber}`, 'no-cache');
    return res;
  }

  return {
    ClockIn
  };
}

export { ApiService, AuthService };
