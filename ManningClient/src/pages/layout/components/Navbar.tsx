import { NavLink } from "react-router-dom";
import ClockOut from "../../../services/authentication/components/ClockOut";
import { useSelector } from "react-redux";
import { RootState } from "../../../types/ReduxTypes";

type TNavBarProps = {
  setEnableLogin: React.Dispatch<React.SetStateAction<boolean>>
}

export default function NavBar(props: TNavBarProps) {

  const user = useSelector((state: RootState) => state.user.currentUser)
  const isAdmin = user?.isAdministrator

  return (
    <nav className="navbar navbar-expand-sm navbar-light bg-light-10">
      <div className="container-fluid">
        <div className="navbar-nav gap-5">
          <h1 className="navbar-brand display-1">Manning Board</h1>
          <NavLink className="nav-link" to="/">
            Home
          </NavLink>
          {
            isAdmin && (
              <>
                <NavLink className="nav-link" to="/station-management">
                Station Management
                </NavLink>
                <NavLink className="nav-link" to="/operator-management">
                  Operator Management
                </NavLink>
              </>
            )
          }
          <ClockOut setEnableLogin={props.setEnableLogin} />
        </div>
        {
          user && 
            <div>
              {user.operatorName}
            </div>
        }
      </div>
    </nav>
  );
}


