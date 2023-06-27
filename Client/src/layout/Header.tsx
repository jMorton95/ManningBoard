import ClockIn from "../../pages/clock-in/ClockIn";
import NavBar from "./Navbar";
import { useAuthContext } from "../hooks/useAuthContext";

export default function Header(): JSX.Element {
  const { token } = useAuthContext();

  return (
    <section className="d-flex header-component">
      {token !== null ? <NavBar /> : <ClockIn />}
    </section>
  );
}
