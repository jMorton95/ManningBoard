import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Home from "./pages/home/Home";
import Layout from "./pages/layout/Layout";
import StationManagement from "./pages/stationManagement/StationManagement";
import OperatorManagement from "./pages/operatorManagement/OperatorManagement";



export default function App() {
  return (
    <BrowserRouter>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="station-management" element={<StationManagement />} />
            <Route path="operator-management" element={<OperatorManagement />}/>
          </Route>
        </Routes>
    </BrowserRouter>
  )
}

