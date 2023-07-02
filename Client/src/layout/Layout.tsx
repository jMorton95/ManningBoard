import Header from "./Header";
import { useAuthContext } from "@/hooks/useAuthContext";
import ClockIn from "@/pages/clock-in/ClockIn";
import { useEffect, useState } from "react";
import { Outlet } from "react-router-dom";

export default function Layout() {
  const { token } = useAuthContext();
  const [headerVisibility, setHeaderVisibility] = useState(true);

  useEffect(() => {
    const handleKeyDown = (e: KeyboardEvent) => {
      if (e.key === "F9") {
        setHeaderVisibility(!headerVisibility);
      }
    };

    window.addEventListener("keydown", handleKeyDown);

    return () => {
      window.removeEventListener("keydown", handleKeyDown);
    };
  }, [headerVisibility]);

  return (
    <div
      className={`h-screen w-screen max-h-screen max-w-screen grid ${
        headerVisibility ? "grid-rows-layout" : "grid-rows-[1rem_1fr]"
      }`}
    >
      {headerVisibility ? (
        <Header className="bg-custom-dark-500 w-full px-4 pt-1" />
      ) : (
        <div className="bg-custom-dark-500 w-full h-24"></div>
      )}
      <main className="w-full flex flex-col h-full bg-gray-100 text-custom-main-200">
        {token ? <Outlet /> : <ClockIn />}
      </main>
    </div>
  );
}
