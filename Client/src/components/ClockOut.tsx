import { useAuthContext } from "../hooks/useAuthContext";

export default function ClockOut() {
  const { CLOCKOUT } = useAuthContext();

  const handleClockOut = (): void => void CLOCKOUT();

  return (
    <a
      href="/"
      className="nav-link active text-jcb-main-200 font-semibold"
      onClick={handleClockOut}
    >
      Clock Out
    </a>
  );
}
