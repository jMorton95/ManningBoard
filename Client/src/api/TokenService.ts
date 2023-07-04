export const GetToken = (): string => {
  const jwt = localStorage.getItem('Jwt');
  return jwt ?? ''
}

export const ClearToken = (): void => {
  localStorage.removeItem('Jwt');
}