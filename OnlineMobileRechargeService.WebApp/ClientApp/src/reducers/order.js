import * as ActionTypes from '../ActionTypes';

const defaultState = {
  selectedPlan: null,
  loading: false,
  order: null,
};

export default (state = defaultState, action) => {
  switch (action.type) {
    case ActionTypes.SELECT_PLAN:
      return {
        ...state,
        selectedPlan: action.payload,
      };

    case ActionTypes.SUBMIT_ORDER:
      return {
        ...state,
        order: {
          ...action.payload,
          ...state.selectedPlan,
        },
      };

    default: return state;
  }
}