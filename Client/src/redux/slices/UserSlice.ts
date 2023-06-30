// import { type PayloadAction, createSlice } from '@reduxjs/toolkit';
// import { type CurrentOperatorState } from '../types/ReduxTypes';
// import { type TOperator } from '../../types/models/Operator';

// const initialState: CurrentOperatorState = {
//   currentOperator: null,
//   sessionID: null
// };
// const userSlice = createSlice({
//   name: 'user',
//   initialState,
//   reducers: {
//     setUser: (state, action: PayloadAction<TOperator | null>) => {
//       state.currentOperator = action.payload;
//     },
//     setSessionID: (state, action: PayloadAction<number | null>) => {
//       state.sessionID = action.payload;
//     },
//     clearUser: (state) => {
//       state.currentOperator = null;
//     },
//     clearSessionID: (state) => {
//       state.sessionID = null;
//     }
//   }
// });

// export const { setUser, setSessionID, clearUser, clearSessionID } = userSlice.actions;

// export default userSlice.reducer;
