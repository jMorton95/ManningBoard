import { useDispatch } from "react-redux"
import { clearToken } from "../authSlice";
import { clearUser } from "../userSlice";
import { Link } from "react-router-dom";

type TClockOutProps = {
  setEnableLogin?: React.Dispatch<React.SetStateAction<boolean>>
}

export default function ClockOut(props: TClockOutProps) {

  const dispatch = useDispatch();

  const clockOutAction = () => {
    dispatch(clearToken());
    dispatch(clearUser());

    if (props.setEnableLogin){
      props.setEnableLogin(false);
    }
  }

  return (
      <Link to="/" className="nav-link active" onClick={clockOutAction}>Clock Out</Link>
  )
};

