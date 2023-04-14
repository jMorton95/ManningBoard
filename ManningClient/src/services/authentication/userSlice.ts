import { PayloadAction, createSlice } from '@reduxjs/toolkit';
import { TCurrentUserState } from '../../types/ReduxTypes';
import { TOperator } from '../../types/OperatorTypes';

const initialState: TCurrentUserState = {
  currentUser: null 
}
const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    setUser: (state, action: PayloadAction<TOperator | null>) => {
      state.currentUser = action.payload;
    },
    clearUser: (state) => {
      state.currentUser = null;
    }
  }
})

export const { setUser, clearUser } = userSlice.actions;

export default userSlice.reducer;