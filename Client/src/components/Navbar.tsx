import Link from 'next/link';

export default function NavBar(): JSX.Element {
  return (
    <nav className="navbar navbar-expand-sm navbar-light bg-light-10">
      <div className="container-fluid">
        <div className="navbar-nav gap-5">
          <h1 className="navbar-brand display-1">Manning Board</h1>
          <Link className="nav-link" href="/">
            Home
          </Link>
          <Link className="nav-link" href="/station-management">
            Station Management
          </Link>
          <Link className="nav-link" href="/operator-management">
            Operator Management
          </Link>
        </div>
      </div>
    </nav>
  );
}
