import { type ReactNode } from "react";
import Header from "./Header";
import Footer from "./Footer";
import { useAuthContext } from "../hooks/useAuthContext";
import ClockIn from "../../pages/clock-in/ClockIn";

type LayoutProps = {
  children: ReactNode;
};

export default function Layout({ children }: LayoutProps) {
  const { token } = useAuthContext();
  return (
    <>
      <Header />
      {token ? children : <ClockIn />}
      <Footer />
    </>
  );
}
