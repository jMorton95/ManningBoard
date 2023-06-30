import ClockOut from "@/components/ClockOut";
import { useAuthContext } from "@/hooks/useAuthContext";
import { type ClassNameProp } from "@/types/HelperTypes";
import { type FC } from "react";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";

type HeaderProps = ClassNameProp;

export default function Header(props: HeaderProps): ReturnType<FC> {
  const { currentOperator } = useAuthContext();
  return (
    <header className={`${props.className} py-2.5`}>
      <div className="flex flex-row justify-between items-center">
        <div className={"text-custom-main-200 font-semibold"}>Manning</div>
        {currentOperator && (
          <div className="flex px-4">
            <div className="flex">
              <Avatar>
                <AvatarImage src="" />
                <AvatarFallback>JM</AvatarFallback>
              </Avatar>
              <p>{currentOperator.operatorName}</p>
            </div>
            <ClockOut />
          </div>
        )}
      </div>
    </header>
  );
}
