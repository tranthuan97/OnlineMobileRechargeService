import { notification } from 'antd';
import { put, takeLeading } from 'redux-saga/effects';

import axios from '../utils/axios';
import { apiErrorHandler } from '../utils';
import * as ActionTypes from '../ActionTypes';

function* getUserTransactions() {
  try {
    const response = yield axios.get('/transactions');

    yield put({
      type: ActionTypes.GET_USER_TRANSACTIONS_SUCCESS,
      payload: response.data.data,
    });

    // notification.success({
    //   message: 'Success',
    //   description: 'Update profile successfully.'
    // });
  } catch (error) {
    apiErrorHandler(error, ActionTypes.GET_USER_TRANSACTIONS_FAILED);
  }
}

export default function* () {
  yield takeLeading(ActionTypes.GET_USER_TRANSACTIONS_PENDING, getUserTransactions);
}