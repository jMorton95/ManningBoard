import { type NonNegativeInteger, type PostParams } from '../types/HelperTypes';
import { API_ENDPOINTS } from '../../config';

/**
 * Gets your base API Url Stored in your Environment Variables & appends the Endpoint you pass in.
 * @param endpoint example: "Zones"
 * @returns A full URL path to your Endpoint.
 */
const BuildUrl = (endpoint: string): string =>
  `${API_ENDPOINTS.base}/api/${endpoint}`;
/**
 * A wrapper on SetState & Fetch
 * @param T The type you expect returned.
 * @param setState The setState function you want to pass fetched data to.
 * @param endpoint The name of the endpoint you're calling.
 */
const AsyncFetchEndpointAndSetState = async <T>(
  setState: React.Dispatch<React.SetStateAction<T | undefined>>,
  endpoint: string,
  token?: string
): Promise<void> => {
  await fetch(BuildUrl(endpoint), {
    headers: {
      Authorization: `Bearer ${token ?? ''}`,
      'Content-Type': 'application/json'
    }
  })
    .then(async(res) => {
      const data: T = await res.json() as T;
      setState(data);
    })
    .catch((error) => {
      console.error(error);
    });
};
/**
 * A wrapper on SetState & Fetch
 * @param T The type you expect returned.
 * @param setState The setState function you want to pass fetched data to.
 * @param endpoint The name of the endpoint you're calling.
 * @param retryAttempts Pass in a max number of retry events for the resource
 */
const AsyncFetchEndpointAndSetStateWithRetry = async <T, N extends number>(
  setState: React.Dispatch<React.SetStateAction<T | undefined>>,
  endpoint: string,
  retryAttempts: NonNegativeInteger<N>,
  token?: string
): Promise<void> => {
  let retry: NonNegativeInteger<N> = retryAttempts;
  while (retry > 0) {
    await fetch(BuildUrl(endpoint), {
      headers: {
        Authorization: `Bearer ${token ?? ''}`
      }
    })
      .then(async res => {
        const data: T = await res.json() as T;
        setState(data);
        retry = 0 as NonNegativeInteger<N>;
      })
      .catch((error) => {
        console.error(error);
        retry--;
      });
  }
};
/**
 * @param data Any Object you wish to build a query string from
 * @returns A string built from destructuring an Objects Keys & Values
 */
const BuildQueryStringFromObject = <T extends object>(data: T): string => {
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
/**
 *  @returns An Object Literal with a method 'POST' and JSON Headers.
 */
function PostRequestBase(token: string): RequestInit {
  return {
    method: 'POST',
    headers: {
      'Content-type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      Authorization: `Bearer ${token}`
    }
  };
}
/**
 * @param param0 Pass an object literal with an Endpoint, Post-Data and request headers.
 * @returns
 */
const FetchPost = async <R, T extends object>(
  {
    endpoint,
    data,
    request
  }: PostParams<T>
): Promise<R> => {
  return await fetch(
    BuildUrl(`${endpoint}/${BuildQueryStringFromObject(data)}`), request
  ).then(async(res) => {
    const data: R = await res.json() as R;
    return await Promise.resolve(data);
  })
    .catch(async(error) => {
      console.error(error);
      return await Promise.reject(error);
    });
};

export { AsyncFetchEndpointAndSetState, AsyncFetchEndpointAndSetStateWithRetry, FetchPost, PostRequestBase, BuildUrl };
