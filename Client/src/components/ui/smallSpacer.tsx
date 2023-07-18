export const SmallSpacer = ({ ...props }: React.HTMLAttributes<HTMLElement>) => (
  <div className={`${props.className ?? ""} h-8 rounded-md px-3`}></div>
);
