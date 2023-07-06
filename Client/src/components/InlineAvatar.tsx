type InlineAvatarProps = React.ImgHTMLAttributes<HTMLImageElement>;

export default function InlineAvatar({ ...props }: InlineAvatarProps) {
  return (
    <img
      className={`p-1 ${props.className}`}
      width={64}
      title={props.title}
      src={props.src}
      content={props.content}
    />
  );
}
