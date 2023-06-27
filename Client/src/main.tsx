import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import "./style/globals.css";
import store from "./redux/store/Store";
import { Provider } from "react-redux";
import { AuthenticationProvider } from "./auth/AuthenticationProvider";

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <AuthenticationProvider>
      <Provider store={store}>
        <App />
      </Provider>
    </AuthenticationProvider>
  </React.StrictMode>
);
