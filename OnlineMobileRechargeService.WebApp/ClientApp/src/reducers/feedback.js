import * as ActionTypes from '../ActionTypes';

const defaultState = {
  loading: false,
  isSuccess: false,
};

export default (state = defaultState, action) => {
  switch (action.type) {
    case ActionTypes.SUBMIT_FEEDBACK:
      return {
        ...state,
        loading: true,
        isSuccess: false,
      };

    case ActionTypes.SUBMIT_FEEDBACK_SUCCESS:
      return {
        ...state,
        loading: false,
        isSuccess: true,
      }
    case ActionTypes.SUBMIT_FEEDBACK_FAILED:
      return {
        ...state,
        loading: false,
        isSuccess: false,
      };

    default:
      return state;
  }
}