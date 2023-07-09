import { Button, type ButtonProps } from "./ui/buttonBase";
import add from "@/icons/add.png";

type AddIconButtonProps = ButtonProps & {
  imgSrc: string;
};

//WIP
export default function AddIconButton(props: AddIconButtonProps) {
  return (
    <div className="h-12 w-12 flex items-end justify-center position-relative">
      <Button variant={"ghost"} size={"icon"} className="h-10 w-10">
        <img src={props.imgSrc} width={64} alt="Assign Operator" />
      </Button>
      <img
        src={add}
        width={16}
        className="position-absolute top-1/2 right-1/2"
        alt="Add"
      />
    </div>
  );
}
