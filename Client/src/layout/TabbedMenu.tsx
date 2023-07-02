import { useAuthContext } from "@/hooks/useAuthContext";
import { type ClassNameProp } from "@/types/HelperTypes";
import { NavLink } from "react-router-dom";

type TabbedMenuProps = ClassNameProp;

export default function TabbedMenu({
  className,
}: TabbedMenuProps): JSX.Element {
  const { currentOperator } = useAuthContext();

  return (
    <nav className={`d-flex ${className}`}>
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
      </div>
    </nav>
  );
}
