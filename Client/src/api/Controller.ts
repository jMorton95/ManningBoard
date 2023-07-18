import { type TLineApi } from "./LineApi";
import { type TLineManagementApi } from "./LineManagementApi";
import { type TStationManagementApi } from "./StationManagementApi";

export type TPublicController = {
  LineApi: TLineApi;
};

export type TPrivateController = {
  LineManagementAPI: ReturnType<TLineManagementApi> | null;
  StationManagementAPI: ReturnType<TStationManagementApi> | null;
};

export type TController = {
  public: TPublicController;
  private: TPrivateController;
};