import { API_ENDPOINTS } from "@/environments/config";


export const GetResponseBase = async(endpoint: string): Promise<Response> => {
  return await fetch(`${API_ENDPOINTS.base}/${endpoint}`, {
    method: 'GET',
    credentials: 'include',
    headers: {
      "Content-Type": "application/json",
    },
  });
};

export const GET = async <T> (endpoint: string): Promise<T | undefined> => {
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