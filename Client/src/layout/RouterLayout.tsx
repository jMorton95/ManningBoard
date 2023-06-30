import { Outlet } from "react-router-dom";
import Menu from "./Menu";

export default function RouterLayout(): JSX.Element {
  return (
    <>
      <Menu />
      <Outlet />
    </>
  );
}
