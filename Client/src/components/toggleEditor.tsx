import { type ClassNameProp } from "@/types/HelperTypes";
import { Toggle } from "./ui/toggle";
import { useAuthContext } from "@/hooks/useAuthContext";
import editOff from "@/icons/edit-off.png";
import editOn from "@/icons/edit-on.png";

type ToggleEditorModeProps = ClassNameProp;

export default function ToggleEditorMode({ className }: ToggleEditorModeProps) {
  const { editorMode, toggleEditorMode } = useAuthContext();

  return (
    <Toggle
      className={`h-10 w-10 ${className}`}
      variant={"default"}
      size={"tab"}
      onClick={toggleEditorMode}
    >
      <img src={editorMode ? editOn : editOff} />
    </Toggle>
  );
}
