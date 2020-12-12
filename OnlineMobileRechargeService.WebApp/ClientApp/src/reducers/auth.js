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

  SET_USER_INFO_PENDING,
  SET_USER_INFO_SUCCESS,
  SET_USER_INFO_FAILED,

  UPDATE_USER_PASSWORD_PENDING,
  UPDATE_USER_PASSWORD_FAILED,
  UPDATE_USER_PASSWORD_SUCCESS,
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
    case SET_USER_INFO_PENDING:
    case UPDATE_USER_PASSWORD_PENDING:
      return {
        ...state,
        loading: true,
      };
    case LOGIN_FAILED:
    case REGISTER_FAILED:
    case SET_USER_INFO_FAILED:
    case UPDATE_USER_PASSWORD_SUCCESS:
    case UPDATE_USER_PASSWORD_FAILED:
      return {
        ...state,
        ready: true,
        loading: false,
      }
    case LOGIN_SUCCESS:
      return {
        ...state,
        ready: true,
        loading: false,
      };

    case REGISTER_SUCCESS:
      return {
        ...state,
        ready: true,
        loading: false,
      };

    case GET_USER_INFO_SUCCESS:
      return {
        ...state,
        ready: true,
        loading: false,
        user: action.payload,
      }

    case SET_USER_INFO_SUCCESS:
      return {
        ...state,
        loading: false,
        user: {
          ...state.user,
          ...action.payload,
        },
      }
    case GET_USER_INFO_FAILED:
      return {
        ...state,
        user: null,
        token: null,
        ready: true,
        loading: false,
      }

    case CHECK_LOCAL_STORAGE_SUCCESS:
      return {
        ...state,
        // ready: true,
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
        user: null,
        token: null,
        ready: true,
        loading: false,
      };

    default: return state;
  }
}