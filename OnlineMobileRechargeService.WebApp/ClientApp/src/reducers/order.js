import * as ActionTypes from '../ActionTypes';

const defaultState = {
  selectedPlan: null,
  loading: false,
  order: null,
  plans: [],
};

export default (state = defaultState, action) => {
  switch (action.type) {
    case ActionTypes.GET_ORDERS_PENDING:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.GET_ORDERS_SUCCESS:
      return {
        ...state,
        loading: false,
        plans: action.payload,
      };

    case ActionTypes.GET_ORDERS_FAILED:
    case ActionTypes.SUBMIT_ORDER_SUCCESS:
    case ActionTypes.SUBMIT_ORDER_FAILED:
      return {
        ...state,
        loading: false,
      };

    case ActionTypes.SUBMIT_ORDER:
      return {
        ...state,
        loading: true,
      };

    default: return state;
  }
}