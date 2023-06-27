import { Link } from "react-router-dom";
import { useContext } from "react";
import { AuthContext } from "../auth/AuthContext";

export default function ClockOut() {
  const { CLOCKOUT } = useContext(AuthContext);

  const handleClockOut = (): void => void CLOCKOUT();

  return (
    <Link to="/" className="nav-link active" onClick={handleClockOut}>
      Clock Out
    </Link>
  );
}
