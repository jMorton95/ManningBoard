import { type ReactNode } from "react";
import { useAuthContext } from "../hooks/useAuthContext";

type LayoutProps = {
  children: ReactNode;
};

export default function Layout({ children }: LayoutProps) {
  const { currentOperator, toggleEditorMode } = useAuthContext();
  return (
    <>
      <header>
        {currentOperator?.isAdministrator == true && (
          <button onClick={toggleEditorMode}>Editor Mode</button>
        )}
        Header
      </header>
      {children}
      <footer>Footer</footer>
    </>
  );
}
