import { type ReactNode } from "react";

type LayoutProps = {
  children: ReactNode;
};

export default function Layout({ children }: LayoutProps) {
  return (
    <>
      <header>Header</header>
      {children}
      <footer>Footer</footer>
    </>
  );
}
