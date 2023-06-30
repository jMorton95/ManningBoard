import { type ReactNode } from "react";
import Header from "./Header";
import Footer from "./Footer";
import { useAuthContext } from "@/hooks/useAuthContext";
import ClockIn from "@/pages/clock-in/ClockIn";

type LayoutProps = {
  children: ReactNode;
};

export default function Layout({ children }: LayoutProps) {
  const { token } = useAuthContext();
  return (
    <div className="h-screen w-screen max-h-screen max-w-screen grid grid-rows-layout">
      <Header className="bg-custom-dark-500 w-full px-4" />
      <main className="w-full flex flex-col h-full text-custom-main-200">
        {token ? children : <ClockIn />}
      </main>
      <Footer className="bg-custom-dark-500 w-full px-4" />
    </div>
  );
}
