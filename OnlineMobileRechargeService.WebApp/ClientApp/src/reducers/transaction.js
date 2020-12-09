import * as ActionTypes from '../ActionTypes';

const defaultState = {
  loading: true,
  transactions: [],
};

export default (state = defaultState, action) => {
  switch (action.type) {
    case ActionTypes.GET_USER_TRANSACTIONS_PENDING:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.GET_USER_TRANSACTIONS_SUCCESS:
      return {
        ...state,
        loading: false,
        transactions: action.payload,
      }

    case ActionTypes.GET_USER_TRANSACTIONS_FAILED:
      return {
        ...state,
        loading: false,
        transactions: action.payload,
      }

    default:
      return state;
  }
}