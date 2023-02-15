import { NonNegativeInteger, PostParams } from "../types/GenericTypes";
/**
 * Gets your base API Url Stored in your Environment Variables & appends the Endpoint you pass in.
 * @param endpoint example: "Zones"
 * @returns A full URL path to your Endpoint.
 */
const BuildUrl = (endpoint: string) =>
 `${import.meta.env.VITE_BASE_API_URL}/api/${endpoint}`;
/**
 * A wrapper on SetState & Fetch
 * @param T The type you expect returned. 
 * @param setState The setState function you want to pass fetched data to.
 * @param endpoint The name of the endpoint you're calling.
 */
const AsyncFetchEndpointAndSetState = async <T>(
  setState: React.Dispatch<React.SetStateAction<T | undefined>>,
  endpoint: string
) => {
  await fetch(BuildUrl(endpoint))
    .then(async (res) => {
      const data: T = await res.json();
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
	retryAttempts: NonNegativeInteger<N>
) => {
	let retry: NonNegativeInteger<N> = retryAttempts;
	while (retry && retry > 0) {
		await fetch(BuildUrl(endpoint))
			.then(async res => {
				const data: T = await res.json();
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
const BuildQueryStringFromObject = <T extends object>(data: T) => {
  let string: string = "?";
  Object.entries(data).forEach((entry) => {
    string += `${entry[0]}=${entry[1]}&`;
  });
  return string;
};
/**
 *  @returns An Object Literal with a method 'POST' and JSON Headers.
 */
function PostRequestBase(): RequestInit {
  return {
		method: "POST",
    headers: {
			"Content-type": "application/json",
			"Access-Control-Allow-Origin": "*"
		},
  };
}
/**
 * @param param0 Pass an object literal with an Endpoint, Post-Data and request headers.
 * @returns 
 */
const FetchPost = async <R, T extends Object>(
	{
		endpoint,
		data,
		request,
	}: PostParams<T>
): Promise<R> => {
	return await fetch(
			BuildUrl(`${endpoint}/${BuildQueryStringFromObject(data)}`), request
		).then(async (res) => {
			let data: R = await res.json();
			return Promise.resolve(data);
		})
		.catch((error) => {
			console.error(error)
			return Promise.reject();
		});
};

export { AsyncFetchEndpointAndSetState, AsyncFetchEndpointAndSetStateWithRetry, FetchPost, PostRequestBase }