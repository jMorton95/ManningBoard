import { useAuthContext } from "@/hooks/useAuthContext";
import RouterLayout from "@/layout/RouterLayout";
import Manning from "@/pages/Manning";
import OperatorManagement from "@/pages/operator-management/OperatorManagement";
import StationManagement from "@/pages/station-management/StationManagement";
import NotAuthorized from "@/pages/unauthorised/Unauthorised";
import { BrowserRouter, Routes, Route } from "react-router-dom";

export default function Router(): JSX.Element {
  const { currentOperator } = useAuthContext();

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<RouterLayout />}>
          <Route index element={<Manning />} />
          <Route
            path="station-management"
            element={
              currentOperator?.isAdministrator === true ? (
                <StationManagement />
              ) : (
                <NotAuthorized />
              )
            }
          />
          <Route
            path="operator-management"
            element={
              currentOperator?.isAdministrator === true ? (
                <OperatorManagement />
              ) : (
                <NotAuthorized />
              )
            }
          />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
