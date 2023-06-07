import { BrowserRouter, Routes, Route } from 'react-router-dom'
import Home from './pages/home/Home'
import Layout from './pages/layout/Layout'
import StationManagement from './pages/stationManagement/StationManagement'
import OperatorManagement from './pages/operatorManagement/OperatorManagement'
import { useSelector } from 'react-redux'
import { type RootState } from './types/ReduxTypes'
import NotAuthorized from './pages/NotAuthorized'

export default function App(): JSX.Element {
  const user = useSelector((state: RootState) => state.user.currentUser)
  const isAdmin = user?.isAdministrator

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
  )
}
