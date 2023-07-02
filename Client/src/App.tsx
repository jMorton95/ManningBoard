import React from "react";
import ReactDOM from "react-dom/client";
import Router from "./components/Router";
import "@/style/globals.css";
import { AuthenticationProvider } from "./auth/AuthenticationProvider";

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <AuthenticationProvider>
      <Router />
    </AuthenticationProvider>
  </React.StrictMode>
);
