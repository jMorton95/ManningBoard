import { type LineStateDTO } from '../types/dtos/LineState';
import { type CurrentOperator } from '../redux/types/ReduxTypes';
import { TZone } from '../types/models/LineTypes';
import { PostParams } from '../types/HelperTypes';
import { GET, GetResponseBase } from '../utilities/APIBase';

type TApiService = {
  GetLineState: () => Promise<LineStateDTO | undefined>
  GetClockedOperator: (clockNumber: string) => Promise<CurrentOperator | undefined>
  GetLine: () => Promise<TZone[] | undefined>
}

export const ApiService = (): TApiService => {
  
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

export const AuthService = (): TAuthService => {

  const setToken = (res: Response) => {
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

  const GetToken = (): string => {
    const jwt = localStorage.getItem('Jwt');
    if (!jwt) {
      throw new Error("No Jwt found in localStorage");
    }
    return jwt ?? ''
  }

   const ClockIn = async (clockCardNumber: string): Promise<CurrentOperator> => {
    const res = await GetResponseBase(`Clock/${clockCardNumber}`);

    if (!res.ok) {
      throw new Error('Response was not OK');
    }

    setToken(res)

    return await res.json().then((data) => {
      return data as CurrentOperator;
    });
  }

  const GetCurrentlyClockedInOperator = async (): Promise<CurrentOperator> => {
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





//TODO: Integrate all the old Api stuff into new Service

/**
 *  @returns An Object Literal with a method 'POST' and JSON Headers.
 */
export function PostRequestBase(): RequestInit {
  //TODO: Integrate with new Service, use Config.
  return {
    method: 'POST',
    credentials: 'include',
    headers: {
      'Content-type': 'application/json',
      'Access-Control-Allow-Origin': 'https://localhost:7001'
    }
  };
}

/**
 * Gets your base API Url Stored in your Environment Variables & appends the Endpoint you pass in.
 * @param endpoint example: "Zones"
 * @returns A full URL path to your Endpoint.
 */
const BuildUrl = (endpoint: string): string =>
  `${import.meta.env.VITE_BASE_API_URL}/api/${endpoint}`;


/**
 * @param param0 Pass an object literal with an Endpoint, Post-Data and request headers.
 * @returns
 */
export const FetchPost = async <R, T extends object>(
  {
    endpoint,
    data,
    request
  }: PostParams<T>
): Promise<R> => {
  return await fetch(
    BuildUrl(`${endpoint}/${BuildQueryStringFromObject(data)}`), request
  ).then(async(res) => {
    console.log(res);
    const data: R = await res.json();
    return await data;
  })
  .catch(async(error) => {
    console.error(error);
    return await Promise.reject(error);
  });
};

/**
 * @param data Any Object you wish to build a query string from
 * @returns A string built from destructuring an Objects Keys & Values
 */
export const BuildQueryStringFromObject = <T extends object>(data: T): string => {
  let queryString: string = '?';
  const dataArray = Object.entries(data);
  dataArray.forEach((entry: [string, string], index) => {
    queryString += `${entry[0]}=${entry[1]}`;
    if (dataArray.length !== index + 1) {
      queryString += '&';
    }
  });
  return queryString;
};
