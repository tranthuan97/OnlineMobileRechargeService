import { push, replace } from 'connected-react-router';
import { all, put, select, takeLeading } from 'redux-saga/effects';

import axios from '../utils/axios';
import { routes } from '../constants';
import { apiErrorHandler } from '../utils';
import * as ActionTypes from '../ActionTypes';
import { notification } from 'antd';

function* selectPlan() {
  yield put(push(routes.Payment));
}

function* submitOrder(action) {
  const { payload } = action;

  const selectedPlan = yield select((state) => state.orderState.selectedPlan);
  try {
    yield axios.post('/transactions', {
      planId: selectedPlan.id,
      paymentCard: payload.paymentCard,
      paymentMethod: payload.paymentMethod === 'PREPAID',
    });

    notification.success({
      message: 'Success',
      description: 'Recharge successfully!',
    });

    yield new Promise((resolve) => setTimeout(resolve, 1500));

    yield all([
      put(replace(routes.Dashboard)),
      put({ type: ActionTypes.SUBMIT_ORDER_SUCCESS }),
    ]);
  } catch (error) {
    apiErrorHandler(error, ActionTypes.SUBMIT_ORDER_FAILED);
  }
}

function* submitPrepaidOrder(action) {
  const { payload } = action;

  const selectedPlan = yield select((state) => state.orderState.selectedPlan);
  try {
    yield axios.post('/transactions/guest', {
      planId: selectedPlan.id,
      paymentCard: payload.paymentCard,
      firstname: payload.firstname,
      lastname: payload.lastname,
      phonenumber: payload.phone,
    });

    notification.success({
      message: 'Success',
      description: 'Recharge successfully!',
    });

    yield put({ type: ActionTypes.SUBMIT_PREPAID_ORDER_SUCCESS });
  } catch (error) {
    apiErrorHandler(error, ActionTypes.SUBMIT_PREPAID_ORDER_FAILED);
  }
}

function* getPlans() {
  try {
    const response = yield axios.get('/plans');

    yield put({
      type: ActionTypes.GET_PLANS_SUCCESS,
      payload: response.data.data
    });
  } catch (error) {
    apiErrorHandler(error, ActionTypes.GET_PLANS_FAILED);
  }
}

export default function* () {
  yield takeLeading(ActionTypes.GET_PLANS_PENDING, getPlans);
  yield takeLeading(ActionTypes.SELECT_PLAN, selectPlan);
  yield takeLeading(ActionTypes.SUBMIT_ORDER, submitOrder);
  yield takeLeading(ActionTypes.SUBMIT_PREPAID_ORDER, submitPrepaidOrder);
}