import { LineProvider } from "@/contexts/LineProvider";
import { OperatorManagementProvider } from "@/contexts/OperatorManagementProvider";
import { StationManagementProvider } from "@/contexts/StationManagementProvider";
import { useAuthContext } from "@/hooks/useAuthContext";
import Layout from "@/layout/Layout";
import Manning from "@/pages/manning/Manning";
import OperatorManagement from "@/pages/operator-management/OperatorManagement";
import StationManagement from "@/pages/station-management/StationManagement";
import NotAuthorized from "@/pages/unauthorised/Unauthorised";
import { BrowserRouter, Routes, Route } from "react-router-dom";

export default function Router(): JSX.Element {
  const { currentOperator } = useAuthContext();

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route
            index
            element={
              <LineProvider>
                <Manning />
              </LineProvider>
            }
          />
          <Route
            path="station-management"
            element={
              currentOperator?.isAdministrator === true ? (
                <StationManagementProvider>
                  <StationManagement />
                </StationManagementProvider>
              ) : (
                <NotAuthorized />
              )
            }
          />
          <Route
            path="operator-management"
            element={
              currentOperator?.isAdministrator === true ? (
                <OperatorManagementProvider>
                  <OperatorManagement />
                </OperatorManagementProvider>
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
