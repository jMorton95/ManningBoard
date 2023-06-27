import ClockIn from "../components/ClockIn";
import { useState } from "react";
import NavBar from "./Navbar";
import { useAuthContext } from "../hooks/useAuthContext";

export default function Header(): JSX.Element {
  const [enableLogin, setEnableLogin] = useState(false);
  const toggleLogin = (): void => {
    setEnableLogin(!enableLogin);
  };
  const { token } = useAuthContext();

  return (
    <section className="d-flex header-component">
      {token === null && (
        <button className="btn btn-primary fw-light fs-6" onClick={toggleLogin}>
          {!enableLogin ? "LogIn" : "Close"}
        </button>
      )}
      {token !== null ? (
        <NavBar setEnableLogin={setEnableLogin} />
      ) : (
        <ClockIn />
      )}
    </section>
  );
}
