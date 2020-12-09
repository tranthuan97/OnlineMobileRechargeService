import { notification } from 'antd';
import { replace } from 'connected-react-router';
import { all, call, put, select, takeLeading } from 'redux-saga/effects';

import axios from '../utils/axios';
import { apiErrorHandler } from '../utils';
import * as ActionTypes from '../ActionTypes';
import { localStorageKey, routes } from '../constants';

function* getUserInfo() {
  try {
    const token = yield select((state) => state.authState.token);

    const Authorization = `Bearer ${token}`;

    const configs = {
      headers: { Authorization },
    }
    const response = yield axios.get('/users/me', configs);

    axios.defaults.headers.Authorization = Authorization;

    yield put({ type: ActionTypes.GET_USER_INFO_SUCCESS, payload: response.data.data });

    yield put(replace(routes.Dashboard));
  } catch (error) {
    // apiErrorHandler(error);
    localStorage.removeItem(localStorageKey.TOKEN);
    yield put({ type: ActionTypes.GET_USER_INFO_FAILED });
  }
}

function* setUserInfo(action) {
  try {
    const response = yield axios.put('/users/me', action.payload);

    yield put({ type: ActionTypes.SET_USER_INFO_SUCCESS, payload: response.data.data });

    notification.success({
      message: 'Success',
      description: 'Update profile successfully.'
    });
  } catch (error) {
    apiErrorHandler(error);
    yield put({ type: ActionTypes.SET_USER_INFO_FAILED });
  }
}

function* checkLocalStorage() {
  const token = localStorage.getItem(localStorageKey.TOKEN)

  const dispatchModel = { type: ActionTypes.CHECK_LOCAL_STORAGE_FAILED };

  if (token) {
    dispatchModel.payload = token;
    dispatchModel.type = ActionTypes.CHECK_LOCAL_STORAGE_SUCCESS;
  }
  yield put(dispatchModel);

  if (token) {
    yield call(getUserInfo);
  }
}

function* loginPending(action) {
  const { payload } = action;
  try {
    const response = yield axios.post('/users/authenticate', {
      Username: payload.username,
      Password: payload.password,
    });

    const { data } = response.data;

    if (payload.remember) {
      localStorage.setItem(localStorageKey.TOKEN, data);
    }

    yield all([
      put({ type: ActionTypes.LOGIN_SUCCESS, payload: data }),
      call(getUserInfo),
    ]);

  } catch (error) {
    apiErrorHandler(error);
    yield put({ type: ActionTypes.LOGIN_FAILED });
  }
}

function* logoutPending() {
  axios.defaults.headers.Authorization = undefined;

  localStorage.removeItem(localStorageKey.TOKEN);
  yield all([
    yield put({ type: ActionTypes.LOGOUT_SUCCESS }),
    yield put(replace(routes.Auth)),
  ]);
}

function* registerPending(action) {
  const { payload } = action;
  try {
    yield axios.post('/users/register', {
      Username: payload.username,
      Password: payload.password,
      ConfirmPassword: payload.confirmPassword,
      FirstName: payload.firstname,
      LastName: payload.lastname,
      Email: payload.email,
      Address: payload.address,
    });

    notification.success({
      message: 'Success',
      description: 'Register successfully. You can login now!'
    });

    yield all([
      put({ type: ActionTypes.REGISTER_SUCCESS }),
      put(replace(routes.Auth)),
    ]);

  } catch (error) {
    apiErrorHandler(error);
    yield put({ type: ActionTypes.REGISTER_FAILED });
  }
}

export default function* () {
  yield takeLeading(ActionTypes.CHECK_LOCAL_STORAGE, checkLocalStorage);
  yield takeLeading(ActionTypes.LOGIN_PENDING, loginPending);
  yield takeLeading(ActionTypes.LOGOUT_PENDING, logoutPending);
  yield takeLeading(ActionTypes.REGISTER_PENDING, registerPending);
  yield takeLeading(ActionTypes.GET_USER_INFO_PENDING, getUserInfo);
  yield takeLeading(ActionTypes.SET_USER_INFO_PENDING, setUserInfo);
}