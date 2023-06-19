import { type PayloadAction, createSlice } from '@reduxjs/toolkit';
import { type LineState } from '../types/ReduxTypes';
import { type LineStateDTO } from '../../types/dtos/LineState';

const initialState: LineState = {
  lineStateDTO: null
};

const lineStateSlice = createSlice({
  name: 'lineState',
  initialState,
  reducers: {
    setLineState: (state, action: PayloadAction<LineStateDTO>) => {
      state.lineStateDTO = action.payload;
    },
    clearLineState: (state) => {
      state.lineStateDTO = null;
    }
  }
});

export const { setLineState, clearLineState } = lineStateSlice.actions;
export default lineStateSlice.reducer;
