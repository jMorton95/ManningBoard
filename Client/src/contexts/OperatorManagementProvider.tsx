import OperatorManagementContextProvider, {
  type TOperatorManagementContextProvider,
} from "./OperatorManagementContext";
import {} from "./StationManagementContext";

export const OperatorManagementProvider = ({ children }: TOperatorManagementContextProvider) => (
  <OperatorManagementContextProvider children={children} />
);
