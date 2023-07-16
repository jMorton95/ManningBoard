import InlineAvatar from "@/components/InlineAvatar";
import { type OperatorAndAvatarDTO } from "@/types/dtos/LineState";
import { binaryStringToImgSrc } from "@/utilities/Helpers";

type AssignedOperatorProps = { dto: OperatorAndAvatarDTO } & React.HTMLAttributes<HTMLDivElement>;

export default function AssignedOperator({ dto, ...props }: AssignedOperatorProps) {
  return (
    <div className={`${props.className ?? ""} px-2 py-2 w-1/2 flex flex-col items-center`}>
      <p className="font-semibold">{props.children}</p>
      <InlineAvatar
        width={54}
        title={`${dto.operator.operatorName} ${dto.avatar.fileName}`}
        src={binaryStringToImgSrc(dto.avatar.fileContent)}
        content={dto.avatar.contentType}
      />
      <p>{dto.operator.operatorName}</p>
    </div>
  );
}
