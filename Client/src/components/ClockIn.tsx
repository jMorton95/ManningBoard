import { useState, type ChangeEvent, type FormEvent } from "react";
import { useDispatch } from "react-redux";
import { setToken } from "../redux/slices/AuthSlice";
import { BuildUrl } from "../services/APIService";
import { setUser, setSessionID } from "../redux/slices/UserSlice";
import { Form } from "react-bootstrap";
import { type CurrentOperator } from "../redux/types/ReduxTypes";
import { AuthService } from "../services/NewApiService";

export default function ClockIn(): JSX.Element {
  const dispatch = useDispatch();
  const [inputText, setInputText] = useState<string>("");
  const { ClockIn } = AuthService();

  const handleLogin = (event: FormEvent<HTMLFormElement>): void => {
    event.preventDefault();
    void submitForm(event);
  };

  const submitForm = async (
    event: FormEvent<HTMLFormElement>
  ): Promise<void> => {
    event.preventDefault();
    try {
      const data = await ClockIn(inputText);

      dispatch(setUser(data.currentOperator));
      dispatch(setSessionID(data.sessionID));
    } catch (error) {
      console.error(error);
    }
  };

  const handleChange = (e: ChangeEvent<HTMLInputElement>): void => {
    setInputText(e.target.value);
  };

  return (
    <Form className="col-12 d-flex flex-row" onSubmit={handleLogin}>
      <Form.Group className="col-6 d-flex flex-row">
        <Form.Label className="col-2">Clock Card Number</Form.Label>
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
      </Form.Group>
    </Form>
  );
}
