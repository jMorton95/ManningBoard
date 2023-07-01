import ClockOut from "@/components/ClockOut";
import { useAuthContext } from "@/hooks/useAuthContext";
import { type FC } from "react";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import avatar from "@public/operator.png";
import { type ClassNameProp } from "@/types/HelperTypes";
import { getInitials } from "@/utilities/Helpers";

type HeaderProps = ClassNameProp;

export default function Header({ className }: HeaderProps): ReturnType<FC> {
  const { currentOperator } = useAuthContext();

  return (
    <header className={`${className} py-2.5`}>
      <div className="flex flex-row justify-between items-center">
        <div className={"text-custom-main-200 font-semibold"}>Manning</div>
        {currentOperator && (
          <div className="flex gap-x-4">
            <Avatar>
              <AvatarImage src={avatar} />
              <AvatarFallback>
                {getInitials(currentOperator.operatorName)}
              </AvatarFallback>
            </Avatar>
            <p className="text-custom-main-200 font-semibold py-2.5">
              {currentOperator.operatorName}
            </p>
            <ClockOut className="" />
          </div>
        )}
      </div>
    </header>
  );
}
