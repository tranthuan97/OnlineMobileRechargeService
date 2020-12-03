import { replace } from 'connected-react-router';
import { all, put, takeLeading } from 'redux-saga/effects';

import axios from '../utils/axios';
import { apiErrorHandler } from '../utils';
import * as ActionTypes from '../ActionTypes';
import { localStorageKey, routes } from '../constants';

function* checkLocalStorage() {
  const token = localStorage.getItem(localStorageKey.TOKEN)

  const dispatchModel = { type: ActionTypes.CHECK_LOCAL_STORAGE_FAILED };

  if (token) {
    dispatchModel.payload = token;
    dispatchModel.type = ActionTypes.CHECK_LOCAL_STORAGE_SUCCESS;
    yield put(replace(routes.Dashboard));
  }
  yield put(dispatchModel);

}

function* loginPending(action) {
  const { payload } = action;
  try {
    const response = yield axios.post('/api/users/authenticate', {
      Username: payload.username,
      Password: payload.password,
    });

    const { data } = response.data;

    if (payload.remember) {
      localStorage.setItem(localStorageKey.TOKEN, data.token);
    }

    yield all([
      yield put({ type: ActionTypes.LOGIN_SUCCESS, payload: data.token }),
      yield put(replace(routes.Dashboard)),
    ]);

  } catch (error) {
    apiErrorHandler(error);
    yield put({ type: ActionTypes.LOGIN_FAILED });
  }
}

function* logoutPending() {
  localStorage.removeItem(localStorageKey.TOKEN);
  yield all([
    yield put({ type: ActionTypes.LOGOUT_SUCCESS }),
    yield put(replace(routes.Login)),
  ]);
}

function* registerPending(action) {
  const { payload } = action;
  try {
    yield axios.post('/api/users/register', {
      Username: payload.username,
      Password: payload.password,
      ConfirmPassword: payload.confirmPassword,
      FirstName: payload.firstname,
      LastName: payload.lastname,
    });

    yield all([
      yield put({ type: ActionTypes.REGISTER_SUCCESS, payload: null }),
      yield put(replace(routes.Auth)),
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
}