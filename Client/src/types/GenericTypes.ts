/**
 * Assert that Number MUST be positive (Greater than or Equal to 0)
 */
type NonNegativeInteger<N extends number> = `${N}` extends `-${string}` ? never : N

/**
 * Post Request Parameters
 */
interface PostParams<T extends object> {
  endpoint: string
  data: T
  request: RequestInit
}

export type { NonNegativeInteger, PostParams }
