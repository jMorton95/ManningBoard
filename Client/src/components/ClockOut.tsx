import { useDispatch, useSelector } from "react-redux";
import { Link } from "react-router-dom";
import { type RootState } from "../redux/types/ReduxTypes";
import { clearToken } from "../redux/slices/AuthSlice";
import { clearUser, clearSessionID } from "../redux/slices/UserSlice";
import { FetchPost, PostRequestBase } from "../services/ApiService";

type TClockOutProps = {
  setEnableLogin?: React.Dispatch<React.SetStateAction<boolean>>;
};

export default function ClockOut(props: TClockOutProps): JSX.Element {
  const sessionID = useSelector((state: RootState) => state.user.sessionID);

  const dispatch = useDispatch();

  const handleClockOut = (): void => {
    void clockOutAction();
  };

  const clockOutAction = async (): Promise<void> => {
    await FetchPost({
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
