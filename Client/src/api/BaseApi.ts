import { API_ENDPOINTS } from "@/environments/config";
import { type PostParams } from "@/types/misc/HelperTypes";


export const GetResponseBase = async(endpoint: string, jwt?: string): Promise<Response> => {
  return await fetch(`${API_ENDPOINTS.base}/${endpoint}`, {
    method: 'GET',
    credentials: 'include',
    headers: {
      "Content-Type": "application/json",
      'Access-Control-Allow-Origin': `${API_ENDPOINTS.domain}`,
      'Authorization': `Bearer ${jwt ?? ''}`
    },
  });
};

/**
 *  @returns An Object Literal with a method 'PostQuery' and JSON Headers.
 */
export function PostRequestBase(body?: BodyInit): RequestInit {
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

export const GET = async <T> (endpoint: string, jwt?: string): Promise<T | undefined> => {
  try {
    const res = await GetResponseBase(endpoint, jwt);

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
