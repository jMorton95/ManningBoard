import { type FC } from "react";
import { type ClassNameProp } from "../types/misc/HelperTypes";
import { useLiveDate } from "@/hooks/useLiveDate";

type FooterProps = ClassNameProp;

export default function Footer({ className }: FooterProps): ReturnType<FC> {
  const date = useLiveDate();

  return (
    <footer className={`${className ?? ""} flex justify-end align-middle`}>
      <div className="text-white font-semibold h-full leading-[3rem]">{date}</div>
    </footer>
  );
}
