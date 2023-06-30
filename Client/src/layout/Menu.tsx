import ClockIn from "../../pages/clock-in/ClockIn";
import NavBar from "./Navbar";
import { useAuthContext } from "../hooks/useAuthContext";

export default function Menu(): JSX.Element {
  return (
    <section className="d-flex header-component">
      <NavBar />
    </section>
  );
}
