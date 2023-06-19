import { type PayloadAction, createSlice } from '@reduxjs/toolkit';
import { type AuthState } from '../types/ReduxTypes';

const initialState: AuthState = {
  token: null
};

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    setToken: (state, action: PayloadAction<string | null>) => {
      state.token = action.payload;
    },
    clearToken: (state) => {
      state.token = null;
    }
  }
});

export const { setToken, clearToken } = authSlice.actions;

export default authSlice.reducer;
