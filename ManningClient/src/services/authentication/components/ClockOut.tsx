import { useDispatch } from "react-redux"
import { clearToken } from "../authSlice";
import { clearUser } from "../userSlice";

export default function ClockOut() {

  const dispatch = useDispatch();

  const clockOutAction = () => {
    dispatch(clearToken());
    dispatch(clearUser());
  }

  return (
      <button type='button' onClick={clockOutAction}>Clock Out</button>
  )
};

