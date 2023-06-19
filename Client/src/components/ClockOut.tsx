import { useDispatch, useSelector } from 'react-redux';
import { Link } from 'react-router-dom';
import { type RootState } from '../redux/types/ReduxTypes';
import { clearToken } from '../redux/slices/AuthSlice';
import { clearUser, clearSessionID } from '../redux/slices/UserSlice';
import { FetchPost, PostRequestBase } from '../services/APIService';

type TClockOutProps = {
  setEnableLogin?: React.Dispatch<React.SetStateAction<boolean>>
}

export default function ClockOut(props: TClockOutProps): JSX.Element {
  const token = useSelector((state: RootState) => state.auth.token);
  const sessionID = useSelector((state: RootState) => state.user.sessionID);

  const dispatch = useDispatch();

  const handleClockOut = (): void => {
    void clockOutAction();
  };

  const clockOutAction = async(): Promise<void> => {
    await FetchPost({
      endpoint: 'Clock',
      data: {
        sessionID
      },
      request: PostRequestBase(token ?? '')
    })
      .then(() => {
        dispatch(clearToken());
        dispatch(clearUser());
        dispatch(clearSessionID());
      });

    if (props.setEnableLogin != null) {
      props.setEnableLogin(false);
    }
  };

  return (
    <Link to="/" className="nav-link active" onClick={handleClockOut}>Clock Out</Link>
  );
};
