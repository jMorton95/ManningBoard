import { useAuthContext } from "@/hooks/useAuthContext";
import { type ClassNameProp } from "@/types/HelperTypes";
import clockout from "@public/icons/clock-out.png";
import { Avatar, AvatarFallback, AvatarImage } from "./ui/avatar";

type ClockOutProps = ClassNameProp;

export default function ClockOut(props: ClockOutProps) {
  const { CLOCKOUT } = useAuthContext();

  const handleClockOut = (): void => void CLOCKOUT();

  return (
    <a
      href="/"
      className={
        "nav-link active text-custom-main-200 font-semibold " + props.className
      }
      onClick={handleClockOut}
    >
      <Avatar>
        <AvatarImage src={clockout} />
        <AvatarFallback>JM</AvatarFallback>
      </Avatar>
    </a>
  );
}
