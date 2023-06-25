import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import { useSelector } from "react-redux";
import { type RootState } from "./redux/types/ReduxTypes";
import { LineStateContextProvider } from "./contexts/LineStateContext";
import StationManagement from "../pages/stationManagement/StationManagement";
import OperatorManagement from "../pages/operatorManagement/OperatorManagement";
import Home from "../pages/home/Home";
import NotAuthorized from "../pages/Unauthorised/Unauthorised";

export default function App(): JSX.Element {
  const user = useSelector((state: RootState) => state.user.currentOperator);
  const isAdmin = user?.isAdministrator;

  return (
    <BrowserRouter>
      <LineStateContextProvider>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route
              path="station-management"
              element={
                isAdmin === true ? <StationManagement /> : <NotAuthorized />
              }
            />
            <Route
              path="operator-management"
              element={
                isAdmin === true ? <OperatorManagement /> : <NotAuthorized />
              }
            />
          </Route>
        </Routes>
      </LineStateContextProvider>
    </BrowserRouter>
  );
}
