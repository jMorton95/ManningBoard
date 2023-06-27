import { Outlet } from "react-router-dom";
import Header from "./Header";

export default function RouterLayout(): JSX.Element {
  return (
    <>
      <Header />
      <main className={"container pt-3"}>
        <Outlet />
      </main>
    </>
  );
}
