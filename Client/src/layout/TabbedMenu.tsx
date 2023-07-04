import { Tabs, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { useAuthContext } from "@/hooks/useAuthContext";
import { type ClassNameProp } from "@/types/misc/HelperTypes";
import { NavLink } from "react-router-dom";

import manning from "@/icons/manning.png";
import station from "@/icons/station.png";
import team from "@/icons/team.png";

import TabBackdrop from "@/components/tabBackdrop";

type TabbedMenuProps = ClassNameProp;

export default function TabbedMenu({
  className,
}: TabbedMenuProps): JSX.Element {
  const { currentOperator } = useAuthContext();

  return (
    <nav className={`d-flex ${className}`}>
      {currentOperator?.isAdministrator === true && (
        <Tabs defaultValue="manning" className="w-auto">
          <TabsList className="h-full bg-custom-dark-500 gap-x-1">
            <TabBackdrop className="w-full border border-custom-dark-300 bg-custom-dark-700">
              <TabsTrigger
                className="h-10 border-none data-[state=inactive]:filter data-[state=inactive]:grayscale data-[state=inactive]:hover:grayscale-50"
                value="manning"
              >
                <NavLink className="nav-link w-full" to="/">
                  <img src={manning} width={40} />
                </NavLink>
              </TabsTrigger>
            </TabBackdrop>

            <TabBackdrop className="w-full border border-custom-dark-300 bg-custom-dark-700">
              <TabsTrigger
                className="h-10 data-[state=inactive]:filter data-[state=inactive]:grayscale data-[state=inactive]:hover:grayscale-50"
                value="station-management"
              >
                <NavLink className="nav-link" to="/station-management">
                  <img src={station} width={40} />
                </NavLink>
              </TabsTrigger>
            </TabBackdrop>

            <TabBackdrop className="w-full border border-custom-dark-300 bg-custom-dark-700">
              <TabsTrigger
                className="h-10 data-[state=inactive]:filter data-[state=inactive]:grayscale data-[state=inactive]:hover:grayscale-50"
                value="operator-management"
              >
                <NavLink className="nav-link" to="/operator-management">
                  <img src={team} width={40} />
                </NavLink>
              </TabsTrigger>
            </TabBackdrop>
          </TabsList>
        </Tabs>
      )}
    </nav>
  );
}
