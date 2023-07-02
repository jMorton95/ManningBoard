import { Button, type ButtonProps } from "./buttonBase";

type KeypadNumberButtonProps = ButtonProps & {
  value: string | number;
  classNames?: string;
};
type KeypadIconButtonProps = ButtonProps & {
  imgsrc: string;
  classNames?: string;
};

export const kepadButtonTheme = `
  rounded-none h-20 w-20 text-lg font-semibold select-none text-custom-dark-400 border border-gray-300 bg-white 
  hover:border-custom-main-300 hover:text-custom-main-200 hover:bg-white focus active:scale-90
`;

export const KeypadButton = ({
  value,
  classNames,
  ...props
}: KeypadNumberButtonProps) => (
  <Button
    variant={"outline"}
    size={"icon"}
    className={`${kepadButtonTheme} ${classNames}`}
    type="button"
    {...props}
  >
    {value}
  </Button>
);

export const KeypadIconButton = ({
  imgsrc,
  classNames,
  ...props
}: KeypadIconButtonProps) => (
  <Button
    variant={"outline"}
    size={"icon"}
    className={`${kepadButtonTheme} ${classNames}`}
    type="button"
    {...props}
  >
    <img src={imgsrc} sizes="24" />
  </Button>
);
