import gear from "@/icons/gear.png";

type LoadingSpinnerProps = React.HtmlHTMLAttributes<HTMLDivElement>;

export const LoadingSpinner = ({ ...props }: LoadingSpinnerProps) => {
  return (
    <div
      className={`${props.className} flex h-full w-full justify-center items-center`}
    >
      <img className="animate-spin duration-1000 h-16 w-16" src={gear} />
    </div>
  );
};
