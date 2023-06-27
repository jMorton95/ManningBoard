import React from "react";
import ReactDOM from "react-dom/client";
import Router from "./components/Router";
import "./style/globals.css";
import store from "./redux/store/Store";
import { Provider } from "react-redux";
import { AuthenticationProvider } from "./auth/AuthenticationProvider";
import Layout from "./layout/Layout";

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <Provider store={store}>
      <Layout>
        <AuthenticationProvider>
          <Router />
        </AuthenticationProvider>
      </Layout>
    </Provider>
  </React.StrictMode>
);
