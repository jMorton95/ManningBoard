import { useState, type ChangeEvent, type FormEvent } from "react";
import { useAuthContext } from "../../src/hooks/useAuthContext";

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

  const handleChange = (e: ChangeEvent<HTMLInputElement>): void => {
    setInputText(e.target.value);
  };

  return (
    <form className="col-12 d-flex flex-row" onSubmit={handleLogin}>
      <div className="col-6 d-flex flex-row">
        <label className="col-2">Clock Card Number</label>
        <input
          type="text"
          className="col-2"
          placeholder="123456"
          required
          minLength={6}
          maxLength={6}
          onChange={handleChange}
        />
        <button className="col-1" type="submit">
          Clock In
        </button>
      </div>
    </form>
  );
}