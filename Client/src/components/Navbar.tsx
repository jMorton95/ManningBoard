import Link from 'next/link';

//type TNavBarProps = {
//setEnableLogin: React.Dispatch<React.SetStateAction<boolean>>
//}

export default function NavBar(): JSX.Element {
  //const user = useSelector((state: RootState) => state.user.currentUser);
  //const isAdmin = user?.isAdministrator;

  return (
    <nav className="navbar navbar-expand-sm navbar-light bg-light-10">
      <div className="container-fluid">
        <div className="navbar-nav gap-5">
          <h1 className="navbar-brand display-1">Manning Board</h1>
          <Link className="nav-link" href="/">
            Home
          </Link>
          {/*{
            isAdmin === true && (
              <> */}
          <Link className="nav-link" href="/station-management">
            Station Management
          </Link>
          <Link className="nav-link" href="/operator-management">
            Operator Management
          </Link>
          {/*</>
            )
          } */}
          {/*<ClockOut setEnableLogin={props.setEnableLogin} /> */}
        </div>
        {/*{
          (user != null) &&
          <div>
            {user.operatorName}
          </div>
        } */}
      </div>
    </nav>
  );
}
