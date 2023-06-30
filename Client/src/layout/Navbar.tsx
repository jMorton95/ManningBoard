import { NavLink } from "react-router-dom";
import { useAuthContext } from "../hooks/useAuthContext";

export default function NavBar(): JSX.Element {
  const { currentOperator } = useAuthContext();

  //TODO: Switch to Tabbed Layout if user is admin.
  return (
    <nav className="">
      <div className="container-fluid">
        <div className="navbar-nav gap-5">
          <NavLink className="nav-link" to="/">
            Manning
          </NavLink>
          {currentOperator?.isAdministrator === true && (
            <>
              <NavLink className="nav-link" to="/station-management">
                Station Management
              </NavLink>
              <NavLink className="nav-link" to="/operator-management">
                Operator Management
              </NavLink>
            </>
          )}
        </div>
        {currentOperator != null && <div>{currentOperator.operatorName}</div>}
      </div>
    </nav>
  );
}
