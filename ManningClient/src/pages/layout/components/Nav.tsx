import { NavLink } from "react-router-dom";

export default function Nav() {
  return (
    <nav className="navbar navbar-expand-sm navbar-light bg-light-10">
      <div className="container-fluid">
        <div className="navbar-nav gap-5">
          <h1 className="navbar-brand display-1">Manning Board</h1>
            <NavLink className="nav-link" to="/">Home</NavLink>
            <NavLink className="nav-link" to="/station-management">Station Management</NavLink>
            <NavLink className="nav-link" to="/operator-management">Operator Management</NavLink>
          </div>
      </div>
    </nav>
  )
}