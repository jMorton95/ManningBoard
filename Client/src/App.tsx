import React from "react";
import ReactDOM from "react-dom/client";
import Router from "./components/Router";
import "@/style/globals.css";
import { AuthenticationProvider } from "./auth/AuthenticationProvider";
import Layout from "./layout/Layout";

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <AuthenticationProvider>
      <Layout>
        <Router />
      </Layout>
    </AuthenticationProvider>
  </React.StrictMode>
);
