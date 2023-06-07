import { useDispatch, useSelector } from "react-redux"
import { clearToken } from "../authSlice";
import { clearSessionID, clearUser } from "../userSlice";
import { Link } from "react-router-dom";
import { FetchPost, PostRequestBase } from "../../APIService";
import { RootState } from "../store";

type TClockOutProps = {
  setEnableLogin?: React.Dispatch<React.SetStateAction<boolean>>
}

export default function ClockOut(props: TClockOutProps) {
  const token = useSelector((state: RootState) => state.auth.token)
  const sessionID = useSelector((state: RootState) => state.user.sessionID)

  const dispatch = useDispatch();

  const clockOutAction = () => {
    FetchPost({
      endpoint: "Clock",
      data: {
        sessionID: sessionID,
      },
      request: PostRequestBase(token!),
    })
    .then(() => {
      dispatch(clearToken());
      dispatch(clearUser());
      dispatch(clearSessionID())
    })
    
    if (props.setEnableLogin){
      props.setEnableLogin(false);
    }
  }

  return (
      <Link to="/" className="nav-link active" onClick={clockOutAction}>Clock Out</Link>
  )
};

