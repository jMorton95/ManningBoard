import { BrowserRouter, Routes, Route } from "react-router-dom";
import RouterLayout from "../layout/RouterLayout";
import StationManagement from "../../pages/station-management/StationManagement";
import OperatorManagement from "../../pages/operator-management/OperatorManagement";
import Home from "../../pages/Home";
import NotAuthorized from "../../pages/unauthorised/Unauthorised";
import { useAuthContext } from "../hooks/useAuthContext";

export default function Router(): JSX.Element {
  const { currentOperator } = useAuthContext();

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<RouterLayout />}>
          <Route index element={<Home />} />
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
