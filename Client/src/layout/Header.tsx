import ClockOut from "@/components/ClockOut";
import { useAuthContext } from "@/hooks/useAuthContext";
import { type FC } from "react";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import avatar from "@public/icons/operator.png";
import { type ClassNameProp } from "@/types/HelperTypes";
import { getInitials } from "@/utilities/Helpers";
import { useLiveDate } from "@/hooks/useLiveDate";
import TabbedMenu from "./TabbedMenu";
import ToggleEditorMode from "@/components/toggleEditor";

type HeaderProps = ClassNameProp;

export default function Header({ className }: HeaderProps): ReturnType<FC> {
  const { currentOperator, editorMode } = useAuthContext();
  const date = useLiveDate();

  return (
    <header className={`${className} py-2.5`}>
      <div className="flex flex-row justify-between items-center select-none">
        <div className="flex flex-row gap-x-6">
          {currentOperator && (
            <div className="flex gap-x-4">
              <p className="text-custom-main-200 font-semibold py-2.5">
                {currentOperator.operatorName}
              </p>
              <Avatar>
                <AvatarImage src={avatar} />
                <AvatarFallback>
                  {getInitials(currentOperator.operatorName)}
                </AvatarFallback>
              </Avatar>
            </div>
          )}
          <p className="text-white font-semibold h-full leading-[3rem]">
            {date}
          </p>
        </div>
        <div>
          <TabbedMenu />
        </div>
        <div className="flex gap-x-2">
          {currentOperator && (
            <>
              <ToggleEditorMode />
              {editorMode && <ClockOut className="" />}
              <ClockOut className="" />
              <ClockOut className="" />
            </>
          )}
        </div>
      </div>
    </header>
  );
}
