import { Outlet } from "react-router-dom";
import Nav from "./components/Nav";

export default function Layout() {
  return (
    <>
      <Nav />
      <main className={"container pt-3"}>
        <Outlet />
      </main>
    </>
  )
};

  
