import InlineAvatar from "@/components/InlineAvatar";
import { OperatorAndAvatarDTO } from "@/types/dtos/LineState";
import blankAvatar from "@/icons/blankavatar.png";
import { binaryStringToImgSrc } from "@/utilities/Helpers";

type AssignedOperatorProps = { dto: OperatorAndAvatarDTO } & React.HTMLAttributes<HTMLDivElement>;

export default function AssignedOperator({ dto, ...props }: AssignedOperatorProps) {
  return (
    <div className="border px-2 py-2 w-1/2">
      <div className={`${props.className}`}>
        {dto ? (
          <>
            <p>{dto.operator.operatorName}</p>
            <InlineAvatar
              width={54}
              title={`${dto.operator.operatorName} ${dto.avatar.fileName}`}
              src={binaryStringToImgSrc(dto.avatar.fileContent)}
              content={dto.avatar.contentType}
            />
          </>
        ) : (
          <>
            <p className="">Empty</p>
            <InlineAvatar width={64} title={`Empty Avatar`} src={blankAvatar} className=" opacity-25" />
          </>
        )}
      </div>
    </div>
  );
}
