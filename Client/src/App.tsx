import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./layout/Layout";
import StationManagement from "../pages/station-management/StationManagement";
import OperatorManagement from "../pages/operator-management/OperatorManagement";
import Home from "../pages/Home";
import NotAuthorized from "../pages/unauthorised/Unauthorised";
import { useAuthContext } from "./hooks/useAuthContext";

export default function App(): JSX.Element {
  const { currentOperator } = useAuthContext();

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
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
