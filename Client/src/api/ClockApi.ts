import { type ResponseMessage } from "@/types/misc/HelperTypes"
import { GetResponseBase, PostWithBody } from "./BaseApi"
import { type CurrentOperator } from "@/types/misc/StatefulTypes"
import { GetToken as getToken, ClearToken } from "./TokenService"

type TClockApi = {
  ClockIn: (clockCardNumber: string) => Promise<CurrentOperator>
  ClockOut: (sessionID: number, ) => Promise<void>
  GetToken(): string
  GetCurrentlyClockedInOperator: () => Promise<CurrentOperator | undefined>
}

export const ClockApi = (): TClockApi => {

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
    ClearToken();
    void await PostWithBody<ResponseMessage, number>("Clock", sessionID);
  }

  const GetToken = getToken;

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