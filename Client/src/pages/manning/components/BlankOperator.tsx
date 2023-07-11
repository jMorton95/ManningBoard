import InlineAvatar from "@/components/InlineAvatar";
import blankAvatar from "@/icons/blankavatar.png";

export default function BlankOperator() {
  return (
    <div className="border px-2 py-2 w-1/2">
      <p className="">Empty</p>
      <InlineAvatar width={64} title={`Empty Avatar`} src={blankAvatar} className=" opacity-25" />
    </div>
  );
}
