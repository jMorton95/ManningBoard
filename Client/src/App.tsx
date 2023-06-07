import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/home/Home";
import Layout from "./pages/layout/Layout";
import StationManagement from "./pages/stationManagement/StationManagement";
import OperatorManagement from "./pages/operatorManagement/OperatorManagement";
import { useSelector } from "react-redux";
import { RootState } from "./types/ReduxTypes";
import NotAuthorized from "./pages/NotAuthorized";


export default function App() {
  const user = useSelector((state: RootState) => state.user.currentUser)
  const isAdmin = user?.isAdministrator

  return (
    <BrowserRouter>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="station-management" element={isAdmin ? <StationManagement /> : <NotAuthorized />} />
            <Route path="operator-management" element={isAdmin ? <OperatorManagement /> : <NotAuthorized />}/>
          </Route>
        </Routes>
    </BrowserRouter>
  )
}

