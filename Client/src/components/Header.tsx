//import ClockIn from './ClockIn';
import NavBar from './Navbar';

export default function Header(): JSX.Element {
  //const [enableLogin, setEnableLogin] = useState(false);

  //const token = useSelector((state: RootState) => state.auth.token);
  //const toggleLogin = (): void => { setEnableLogin(!enableLogin); };

  return (
    <section className="d-flex header-component">
      {/*{token === null && (
        <button className="btn btn-primary fw-light fs-6" onClick={toggleLogin}>
          {!enableLogin ? 'LogIn' : 'Close'}
        </button>
      )}
      {enableLogin && (
        token !== null */}

      <NavBar />

    </section>
  );
}
