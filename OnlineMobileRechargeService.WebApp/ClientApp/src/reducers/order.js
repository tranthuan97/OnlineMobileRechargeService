import * as ActionTypes from '../ActionTypes';

const defaultState = {
  selectedPlan: null,
  loading: false,
  order: null,
  plans: [],
};

export default (state = defaultState, action) => {
  switch (action.type) {
    case ActionTypes.GET_PLANS_PENDING:
      return {
        ...state,
        loading: true,
      };

    case ActionTypes.SELECT_PLAN:
    case ActionTypes.PREPAID_SELECT_PLAN:
      return {
        ...state,
        selectedPlan: action.payload,
      };

    case ActionTypes.GET_PLANS_SUCCESS:
      return {
        ...state,
        loading: false,
        plans: action.payload,
      };

    case ActionTypes.SUBMIT_PREPAID_ORDER_SUCCESS:
      return {
        ...state,
        loading: false,
        selectedPlan: {
          ...state.selectedPlan,
          paymented: true,
        }
      }

    case ActionTypes.GET_PLANS_FAILED:
    case ActionTypes.SUBMIT_ORDER_FAILED:
      return {
        ...state,
        loading: false,
      };
    case ActionTypes.SUBMIT_ORDER_SUCCESS:
      return {
        ...state,
        loading: false,
        selectedPlan: null,
      };

    case ActionTypes.SUBMIT_ORDER:
      return {
        ...state,
        loading: true,
      };

    default: return state;
  }
}