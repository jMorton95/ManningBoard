import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Layout from './components/Layout';
import { useSelector } from 'react-redux';
import { type RootState } from './redux/types/ReduxTypes';
import NotAuthorized from '../pages/Unauthorised/Unauthorised';
import Home from '../pages/Home';
import OperatorManagement from '../pages/OperatorManagement';
import StationManagement from '../pages/StationManagement';
import { LineStateContextProvider } from './contexts/LineStateContext';
import { type ReactNode } from 'react';

export default function App(): ReactNode {
  const user = useSelector((state: RootState) => state.user.currentUser);
  const isAdmin = user?.isAdministrator;

  return (
    <BrowserRouter>
      <LineStateContextProvider>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="station-management" element={isAdmin === true ? <StationManagement /> : <NotAuthorized />}
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
