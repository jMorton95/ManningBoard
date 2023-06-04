import { useSelector } from "react-redux";
import { RootState } from "../../../types/ReduxTypes";
import ClockIn from "../../../services/authentication/components/ClockIn";
import { useState } from "react";
import NavBar from "./Navbar";

export default function Header() {
  const [enableLogin, setEnableLogin] = useState(false);
  const token = useSelector((state: RootState) => state.auth.token);
  const user = useSelector((state: RootState) => state.user.currentUser);
  const toggleLogin = () => setEnableLogin(!enableLogin);

return (
    <section className="d-flex header-component">
      {!token && !user && (
        <button className="btn btn-primary fw-light fs-6" onClick={toggleLogin}>
          {!enableLogin ? "Management" : "Close"}
        </button>
      )}
      {enableLogin &&
        (token && user ? (
          <NavBar setEnableLogin={setEnableLogin} />
        ) : (
          <ClockIn />
        ))}
    </section>
  );
}
