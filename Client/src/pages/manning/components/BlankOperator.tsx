import InlineAvatar from "@/components/InlineAvatar";
import blankAvatar from "@/icons/blankavatar.png";

type BlankOperatorProps = React.HTMLAttributes<HTMLDivElement>;

export default function BlankOperator({ ...props }: BlankOperatorProps) {
  return (
    <div className={`${props.className} px-2 py-2 w-1/2 flex flex-col items-center`}>
      <p className="font-semibold">Operator:</p>
      <InlineAvatar width={64} title={`Empty Avatar`} src={blankAvatar} className=" opacity-25" />
    </div>
  );
}
