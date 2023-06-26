/**
 * Assert that Number MUST be positive (Greater than or Equal to 0)
 */
type NonNegativeInteger<N extends number> = `${N}` extends `-${string}` ? never : N

/**
 * PostQuery Request Parameters
 */
type PostParams<T extends object> = {
  endpoint: string
  data: T
  request: RequestInit
}

export type ResponseMessage = {
  message: string
}

export type { NonNegativeInteger, PostParams };
