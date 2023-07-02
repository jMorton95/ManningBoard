import Header from "./Header";
import { useAuthContext } from "@/hooks/useAuthContext";
import ClockIn from "@/pages/clock-in/ClockIn";
import { Outlet } from "react-router-dom";

export default function Layout() {
  const { token } = useAuthContext();

  return (
    <div className="h-screen w-screen max-h-screen max-w-screen grid grid-rows-layout">
      <Header className="bg-custom-dark-500 w-full px-4" />
      <main className="w-full flex flex-col h-full bg-gray-100 text-custom-main-200">
        {token ? <Outlet /> : <ClockIn />}
      </main>
    </div>
  );
}
