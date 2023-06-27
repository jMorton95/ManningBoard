import { Link } from "react-router-dom";
import { useContext } from "react";
import { AuthContext } from "../contexts/AuthContext";

type TClockOutProps = {
  setEnableLogin?: React.Dispatch<React.SetStateAction<boolean>>;
};

export default function ClockOut(): JSX.Element {
  const { CLOCKOUT } = useContext(AuthContext);

  const handleClockOut = (): void => {
    void CLOCKOUT();
  };

  return (
    <Link to="/" className="nav-link active" onClick={handleClockOut}>
      Clock Out
    </Link>
  );
}
