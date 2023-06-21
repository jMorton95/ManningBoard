import { ReactNode } from "react";
import Header from "./Header";

type LayoutProps = { children?: ReactNode }

export default function Layout({ children }: LayoutProps) {
  return (
    <>
      <Header />
      <main className={'container pt-3'}>
        {children}
      </main>
    </>
  );
};
