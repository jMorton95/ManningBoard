const BASE_API_ENDPOINT = `${import.meta.env.VITE_BASE_API_URL}`;

export const API_ENDPOINTS = {
  domain: BASE_API_ENDPOINT,
  base: `${BASE_API_ENDPOINT}/api`,
  lineState: `${BASE_API_ENDPOINT}/LineState`
};
