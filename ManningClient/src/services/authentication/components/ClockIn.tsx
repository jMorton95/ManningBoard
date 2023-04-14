import React, { useState, ChangeEvent, FormEvent } from 'react';
import { useDispatch } from 'react-redux';
import { setToken } from '../authSlice';
import { BuildUrl } from '../../APIService';
import { setUser } from '../userSlice';
import { Form, Button, FormControl } from 'react-bootstrap';
import { TCurrentUser } from '../../../types/ReduxTypes';

const ClockIn = () => {
  const dispatch = useDispatch();
  const [inputText, setInputText] = useState<string>('');

  const handleLogin = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    try {
      const response = await fetch(BuildUrl(`Login/${inputText}`));

      if (!response.ok) {
        console.error('error');
        return 'error';
      }

      const data: TCurrentUser = await response.json();

      dispatch(setToken(data.jsonWebToken));
      dispatch(setUser(data.currentOperator));
      
    } catch (error) {
      console.error('There was a problem with the fetch operation:', error);
    }
  };

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    setInputText(e.target.value);
  }

  return (
    <Form className="col-12 d-flex flex-row" onSubmit={handleLogin}>
     <Form.Group className="col-6 d-flex flex-row">
      <Form.Label className="col-2">Clock Card Number</Form.Label>
      <FormControl type="text" className="col-2" placeholder="123456" required minLength={6} maxLength={6} onChange={handleChange} />
      <Button className="col-1" variant="primary" type="submit">Clock In</Button>
     </Form.Group>
    </Form>
  );
};

export default ClockIn;