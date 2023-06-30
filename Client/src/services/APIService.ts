import { type LineStateDTO } from '../types/dtos/LineState';
import { type CurrentOperator } from '../types/StatefulTypes';
import { type TZone } from '../types/models/LineTypes';
import { type ResponseMessage, type PostParams } from '../types/HelperTypes';
import { GET, GetResponseBase } from '../utilities/APIBase';
import { API_ENDPOINTS } from '../../config';

type TPublicApiService = {
  GetLineState: () => Promise<LineStateDTO | undefined>
  GetLine: () => Promise<TZone[] | undefined>
}

export const PublicApiService = (): TPublicApiService => {
  
  const GetLineState = async() => await GET<LineStateDTO>('Line/GetLineState');
  const GetLine = async() => await GET<TZone[]>('Line');

  return {
    GetLineState,
    GetLine
  };
}

type TPrivateApiService = {
  ClockIn: (clockCardNumber: string) => Promise<CurrentOperator>
  ClockOut: (sessionID: number, ) => Promise<void>
  GetToken(): string
  GetCurrentlyClockedInOperator: () => Promise<CurrentOperator | undefined>
}

export const PrivateApiService = (): TPrivateApiService => {

  const SetToken = (res: Response) => {
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
    return jwt ?? ''
  }

  const ClearToken = (): void => {
    localStorage.removeItem('Jwt');
  }

  const ClockIn = async (clockCardNumber: string): Promise<CurrentOperator> => {
    const res = await GetResponseBase(`Clock/${clockCardNumber}`);

    if (!res.ok) {
      throw new Error('Response was not OK');
    }

    SetToken(res)

    return await res.json().then((data) => {
      return data as CurrentOperator;
    });
  }

 

  const ClockOut = async (sessionID: number): Promise<void> => {
    const message = await PostWithBody<ResponseMessage, number>("Clock", sessionID);

    if (message) {
      ClearToken();
    }
  }

  const GetCurrentlyClockedInOperator = async (): Promise<CurrentOperator | undefined> => {
    //TODO: Refactor this without the magic string for generating the endpoint.
    const res = await GetResponseBase(`Clock/GetOperatorFromJWT?jwt=${GetToken()}`);

    if (!res.ok) {
      ClearToken();
      throw new Error(`Response was not OK, ${res.statusText}`);
    }

    return await res.json().then((data) => {
      return data as CurrentOperator;
    });
  }

  return {
    ClockIn,
    ClockOut,
    GetToken,
    GetCurrentlyClockedInOperator
  };
}





//TODO: Integrate all the old Api stuff into new Service

/**
 *  @returns An Object Literal with a method 'PostQuery' and JSON Headers.
 */
export function PostRequestBase(body?: BodyInit): RequestInit {
  //TODO: Integrate with new Service, use Config.
  return {
    method: 'POST',
    credentials: 'include',
    headers: {
      'Content-type': 'application/json',
      'Access-Control-Allow-Origin': `${API_ENDPOINTS.domain}`
    },
    body: body ?? null
  };
}

export const PostWithBody = async <T, R> (endpoint: string, body: R) => {
  const res =  await fetch((`${API_ENDPOINTS.base}/${endpoint}`), PostRequestBase(JSON.stringify(body)))
  
  if (!res.ok) {
    throw new Error(`Post Request Error, ${res.statusText}`)
  }

  return await res.json()
    .then((data) => {
      return data as T
    })
}

/**
 * @param param0 Pass an object literal with an Endpoint, PostQuery-Data and request headers.
 * @returns
 */
export const PostQuery = async <R, T extends object>(
  {
    endpoint,
    request,
    data,
  }: PostParams<T>
): Promise<R> => {
  return await fetch((`${API_ENDPOINTS.base}/${endpoint}/${BuildQueryStringFromObject(data)}`), request)
    .then(async(res) => {
      const data: R = await res.json() as R;
      return data;
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
  let queryString = '?';
  const dataArray = Object.entries(data);

  dataArray.forEach((entry: [string, string], index) => {
    queryString += `${entry[0]}=${entry[1]}`;

    if (dataArray.length !== index + 1) {
      queryString += '&';
    }
  });
  
  return queryString;
};
