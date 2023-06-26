import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import "./style/globals.css";
import { Provider } from "react-redux";
import store from "./redux/store/Store";
import { AuthContextProvider } from "./contexts/AuthContext";

ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <Provider store={store}>
      <AuthContextProvider>
        <App />
      </AuthContextProvider>
    </Provider>
  </React.StrictMode>
);
