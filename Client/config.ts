if (process.env.NEXT_PUBLIC_API_ENDPOINT === undefined) {
  throw new Error('NEXT_PUBLIC_API_ENDPOINT is not defined');
}

export const API_ENDPOINTS = {
  base: process.env.NEXT_PUBLIC_API_ENDPOINT
};
