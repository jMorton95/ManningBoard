import ClockOut from "@/components/ClockOut";
import { useAuthContext } from "@/hooks/useAuthContext";
import { SyntheticEvent, type FC } from "react";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import avatar from "@public/icons/operator.png";
import { type ClassNameProp } from "@/types/HelperTypes";
import { getInitials } from "@/utilities/Helpers";
import { useLiveDate } from "@/hooks/useLiveDate";
import TabbedMenu from "./TabbedMenu";
import ToggleEditorMode from "@/components/toggleEditor";
import TabBackdrop from "@/components/tabBackdrop";
import {
  HoverCard,
  HoverCardContent,
  HoverCardTrigger,
} from "@/components/ui/hover-card";

type HeaderProps = ClassNameProp;

export default function Header({ className }: HeaderProps): ReturnType<FC> {
  const { currentOperator, editorMode } = useAuthContext();
  const date = useLiveDate();

  return (
    <header className={`${className} py-2.5`}>
      <div className="flex flex-row justify-between items-center select-none">
        <div className="flex flex-row gap-x-6">
          <div className="flex gap-x-4">
            <p className="text-custom-main-200 font-semibold py-2.5">
              {currentOperator ? currentOperator.operatorName : "Manning"}
            </p>
            {currentOperator && (
              <Avatar>
                <AvatarImage src={avatar} />
                <AvatarFallback>
                  {getInitials(currentOperator.operatorName)}
                </AvatarFallback>
              </Avatar>
            )}
          </div>

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
              <TabBackdrop
                className={`${
                  editorMode
                    ? "bg-custom-dark-700 border-custom-dark-100"
                    : "bg-custom-dark-500 border-custom-dark-100"
                }`}
              >
                <HoverCard>
                  <HoverCardTrigger>
                    <ToggleEditorMode />
                  </HoverCardTrigger>
                  <HoverCardContent className="w-40 font-semibold text-xs">
                    Toggle Editor Mode
                  </HoverCardContent>
                </HoverCard>
              </TabBackdrop>

              <TabBackdrop className="bg-custom-dark-700 border-custom-dark-100">
                <HoverCard>
                  <HoverCardTrigger href="/">
                    <ClockOut />
                  </HoverCardTrigger>
                  <HoverCardContent className="w-40 font-semibold text-xs">
                    Clock Out
                  </HoverCardContent>
                </HoverCard>
              </TabBackdrop>
            </>
          )}
        </div>
      </div>
    </header>
  );
}
