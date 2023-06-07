import { Outlet } from "react-router-dom";
import Header from "./components/Header";

export default function Layout() {
  return (
    <>
      <Header />
      <main className={"container pt-3"}>
        <Outlet />
      </main>
    </>
  )
};

  
