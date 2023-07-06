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
