import { useState, type FormEvent } from "react";
import { useAuthContext } from "@/hooks/useAuthContext";
import { Input } from "@/components/ui/input";
import { KeypadButton, KeypadIconButton } from "@/components/keypadButton";
import undo from "@/icons/undo.png";
import arrow from "@/icons/right-arrow.png";

export default function ClockIn(): JSX.Element {
  const [inputText, setInputText] = useState<string>("");
  const { CLOCKIN } = useAuthContext();

  const handleLogin = (event: FormEvent<HTMLFormElement>): void => {
    event.preventDefault();
    void submitForm(event);
  };

  const submitForm = async (
    event: FormEvent<HTMLFormElement>
  ): Promise<void> => {
    event.preventDefault();
    try {
      await CLOCKIN(inputText);
    } catch (error) {
      console.error(error);
    }
  };

  const handleClick = (value: number): void => {
    setInputText((prev) => prev + value);
  };

  const handleBackspace = (): void => {
    setInputText(inputText.slice(0, -1));
  };

  const numbers = Array.from({ length: 9 }, (_, i) => i + 1);

  return (
    <form onSubmit={handleLogin} className="flex justify-center h-full">
      <div className="mt-[5%] h-80 w-64 justify-between items-center grid grid-cols-3 gap-3">
        <Input
          type={"password"}
          readOnly
          value={inputText}
          className="w-[260px] col-span-3 rounded-none border border-gray-300 font-semibold text-xl text-center tracking-widest focus-within:border-gray-500 focus-within:shadow-none"
          max={6}
        />
        {numbers.map((num, i) => (
          <KeypadButton
            value={num}
            key={i}
            disabled={inputText.length >= 6}
            onClick={() => handleClick(num)}
          />
        ))}
        <KeypadIconButton
          classNames="bg-gray-200"
          imgSrc={undo}
          imgSize={28}
          onClick={handleBackspace}
          disabled={inputText.length < 1}
        />
        <KeypadButton
          value={0}
          disabled={inputText.length >= 6}
          onClick={() => handleClick(0)}
        />
        <KeypadIconButton
          classNames={`${
            inputText.length >= 6 ? "bg-custom-main-200" : "bg-white"
          } hover:bg-custom-main-200 hover:border-gray-500`}
          imgSrc={arrow}
          imgSize={28}
          type="submit"
          disabled={inputText.length < 6}
        />
      </div>
    </form>
  );
}
