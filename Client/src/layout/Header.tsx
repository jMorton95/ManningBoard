import { type FC } from "react";
import { type ClassNameProp } from "../types/HelperTypes";
import ClockOut from "../components/ClockOut";
import { useAuthContext } from "../hooks/useAuthContext";

type HeaderProps = ClassNameProp;

export default function Header(props: HeaderProps): ReturnType<FC> {
  const { currentOperator } = useAuthContext();
  return (
    <header className={`${props.className} py-2.5`}>
      <div className="flex flex-row justify-between items-center">
        <div className={"text-jcb-main-200 font-semibold"}>Manning</div>
        {currentOperator && <ClockOut />}
      </div>
    </header>
  );
}
