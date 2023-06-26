import { Outlet } from "react-router-dom";
import Header from "../src/components/Header";

export default function Layout(): JSX.Element {
  return (
    <>
      <Header />
      <main className={"container pt-3"}>
        <Outlet />
      </main>
    </>
  );
}
