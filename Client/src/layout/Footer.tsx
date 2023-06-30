import { type FC } from "react";
import { type ClassNameProp } from "../types/HelperTypes";

type FooterProps = ClassNameProp;

export default function Footer(props: FooterProps): ReturnType<FC> {
  return (
    <footer className={`${props.className} `}>
      <div>Footer</div>
    </footer>
  );
}
