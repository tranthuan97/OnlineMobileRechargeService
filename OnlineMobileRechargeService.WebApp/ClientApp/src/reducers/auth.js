import {
  LOGIN_PENDING,
  LOGIN_SUCCESS,
  LOGIN_FAILED,

  CHECK_LOCAL_STORAGE_SUCCESS,
  CHECK_LOCAL_STORAGE_FAILED,

  LOGOUT_SUCCESS,

  REGISTER_PENDING,
  REGISTER_SUCCESS,
  REGISTER_FAILED,

  GET_USER_INFO_PENDING,
  GET_USER_INFO_SUCCESS,
  GET_USER_INFO_FAILED,
} from '../ActionTypes';

const defaultState = {
  ready: false,
  loading: false,
  token: null,
  user: null,
}

export default (state = defaultState, action) => {
  switch (action.type) {
    case LOGIN_PENDING:
    case REGISTER_PENDING:
    case GET_USER_INFO_PENDING:
      return {
        ...state,
        loading: true,
      };
    case LOGIN_SUCCESS:
    case REGISTER_SUCCESS:
    case GET_USER_INFO_SUCCESS:
      return {
        ...state,
        ready: false,
        loading: false,
        token: action.payload,
      };
    case LOGIN_FAILED:
    case REGISTER_FAILED:
    case GET_USER_INFO_FAILED:
      return {
        ...state,
        ready: false,
        loading: false,
      }

    case CHECK_LOCAL_STORAGE_SUCCESS:
      return {
        ...state,
        ready: true,
        token: action.payload,
      };

    case CHECK_LOCAL_STORAGE_FAILED:
      return {
        ...state,
        ready: true,
      };

    case LOGOUT_SUCCESS:
      return {
        ...state,
        token: null,
      };

    default: return state;
  }
}