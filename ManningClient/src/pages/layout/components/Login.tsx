import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setToken } from '../../../services/authentication/authSlice';
import { BuildUrl } from '../../../services/APIService';
import { setUser } from '../../../services/authentication/userSlice';
import {Form, Button, FormControl } from 'react-bootstrap';
import { TCurrentUser } from '../../../types/OperatorTypes';
import { RootState } from '../../../services/authentication/store';

const Login = () => {
  const dispatch = useDispatch();
  const token = useSelector((state: RootState) => state.auth.token);
  const [inputText, setInputText] = useState<string>('');

  const handleLogin = async (event: { preventDefault: () => void; }) => {
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

  const handleChange = (e: { target: { value: React.SetStateAction<string>; }; }) => {
    setInputText(e.target.value);
  }

  return (
    <Form className="mx-auto col-6 py-3 flex-column" onSubmit={handleLogin}>
     <Form.Group className="col-3 py-3">
      <Form.Label>Clock Card Number</Form.Label>
      <FormControl type="text" placeholder="123456" required minLength={6} maxLength={6} onChange={handleChange} />
     </Form.Group>
      <Button variant="primary" type="submit">Login</Button>
    </Form>
  );
};

 


export default Login;