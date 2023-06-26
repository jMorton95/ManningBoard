import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { type RootState } from "../redux/types/ReduxTypes";
import { clearToken } from "../redux/slices/AuthSlice";
import { clearUser, clearSessionID } from "../redux/slices/UserSlice";
import { PostQuery, PostRequestBase } from "../services/ApiService";
import { useContext } from "react";
import { AuthContext } from "../contexts/AuthContext";

type TClockOutProps = {
  setEnableLogin?: React.Dispatch<React.SetStateAction<boolean>>;
};

export default function ClockOut(props: TClockOutProps): JSX.Element {
  const sessionID = useSelector((state: RootState) => state.user.sessionID);
  const { CLOCKOUT } = useContext(AuthContext);

  const dispatch = useDispatch();

  const handleClockOut = (): void => {
    void CLOCKOUT();
  };

  const clockOutAction = async (): Promise<void> => {
    await PostQuery({
      endpoint: "Clock",
      data: {
        sessionID,
      },
      request: PostRequestBase(),
    }).then(() => {
      dispatch(clearToken());
      dispatch(clearUser());
      dispatch(clearSessionID());
    });

    if (props.setEnableLogin != null) {
      props.setEnableLogin(false);
    }
  };

  return (
    <Link to="/" className="nav-link active" onClick={handleClockOut}>
      Clock Out
    </Link>
  );
}
