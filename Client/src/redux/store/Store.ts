import { configureStore } from '@reduxjs/toolkit';
import authReducer from '../slices/AuthSlice';
import userReducer from '../slices/UserSlice';
import lineStateReducer from '../slices/LineStateSlice';

const store = configureStore({
  reducer: {
    auth: authReducer,
    user: userReducer,
    lineState: lineStateReducer
  }
});

export type RootState = ReturnType<typeof store.getState>
export default store;
