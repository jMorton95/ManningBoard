import { useAuthContext } from "@/hooks/useAuthContext";
import { type ClassNameProp } from "@/types/HelperTypes";
import exit from "@/icons/exit.png";
import { Avatar, AvatarFallback, AvatarImage } from "./ui/avatar";

type ClockOutProps = ClassNameProp;

export default function ClockOut(props: ClockOutProps) {
  const { CLOCKOUT } = useAuthContext();

  const handleClockOut = (): void => void CLOCKOUT();

  return (
    <p
      className={
        "nav-link active text-custom-main-200 font-semibold " + props.className
      }
      onClick={handleClockOut}
    >
      <Avatar className="rounded-none hover:scale-105">
        <AvatarImage src={exit} />
        <AvatarFallback>JM</AvatarFallback>
      </Avatar>
    </p>
  );
}
