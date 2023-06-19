import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Home from './pages/Home/Home';
import Layout from './components/Layout';
import StationManagement from './pages/StationManagement/StationManagement';
import OperatorManagement from './pages/OperatorManagement/OperatorManagement';
import { useSelector } from 'react-redux';
import { type RootState } from './redux/types/ReduxTypes';
import NotAuthorized from './pages/Unauthorised/Unauthorised';
import { useLineState } from './services/LineStateHook';

export default function App(): JSX.Element {
  const user = useSelector((state: RootState) => state.user.currentUser);
  const isAdmin = user?.isAdministrator;
  useLineState();

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<Home />} />
          <Route path="station-management" element={isAdmin === true ? <StationManagement /> : <NotAuthorized />} />
          <Route path="operator-management" element={isAdmin === true ? <OperatorManagement /> : <NotAuthorized />}/>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
