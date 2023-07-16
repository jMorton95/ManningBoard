import { type ClassNameProp } from "@/types/misc/HelperTypes";
import { type ReactNode } from "react";

type TabBackdropProps = ClassNameProp & {
  children?: ReactNode;
};

export default function TabBackdrop({ children, className }: TabBackdropProps) {
  return (
    <div className={`${className ?? ""} h-14 w-14 border rounded-t-md px-2 flex flex-col justify-center align-center`}>
      {children}
    </div>
  );
}
