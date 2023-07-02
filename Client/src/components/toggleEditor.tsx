import { type ClassNameProp } from "@/types/HelperTypes";
import { Toggle } from "./ui/toggle";
import { useAuthContext } from "@/hooks/useAuthContext";

type ToggleEditorModeProps = ClassNameProp;

export default function ToggleEditorMode({ className }: ToggleEditorModeProps) {
  const { toggleEditorMode } = useAuthContext();

  return (
    <Toggle
      className={` ${className}`}
      variant={"default"}
      onClick={toggleEditorMode}
    >
      Hi
    </Toggle>
  );
}
