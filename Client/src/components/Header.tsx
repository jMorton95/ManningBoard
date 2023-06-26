import ClockIn from "./ClockIn";
import { useContext, useState } from "react";
import NavBar from "./Navbar";
import { AuthContext } from "../contexts/AuthContext";

export default function Header(): JSX.Element {
  const [enableLogin, setEnableLogin] = useState(false);
  const toggleLogin = (): void => {
    setEnableLogin(!enableLogin);
  };
  const { token } = useContext(AuthContext);

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
