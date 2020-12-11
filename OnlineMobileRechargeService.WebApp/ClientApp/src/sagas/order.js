import { push } from 'connected-react-router';
import { put, select, takeLeading } from 'redux-saga/effects';

import axios from '../utils/axios';
import { routes } from '../constants';
import { apiErrorHandler } from '../utils';
import * as ActionTypes from '../ActionTypes';

function* selectPlan() {
  yield put(push(routes.Payment));
}

function* submitOrder(action) {
  console.log('🚀 ~ file: order.js ~ line 14 ~ function*submitOrder ~ action', action)
  const { payload } = action;
  const selectedPlan = yield select((state) => state.orderState.selectedPlan);
  // const selectedPlan = yield select((state) => state.orderState.selectedPlan);
  console.log('🚀 ~ file: order.js ~ line 16 ~ function*submitOrder ~ selectedPlan', selectedPlan)
  try {
    yield axios.post('/transactions', {
      planId: selectedPlan.id,
      firstname: payload.firstname,
      lastname: payload.lastname,
      address: payload.address,
      phone: payload.phone,
      paymentCard: payload.paymentCard,
    });

    yield put({ type: ActionTypes.SUBMIT_ORDER_SUCCESS });
  } catch (error) {
    apiErrorHandler(error, ActionTypes.SUBMIT_ORDER_FAILED);
  }
}

function* getOrders() {
  try {
    const response = yield axios.get('/plans');

    yield put({
      type: ActionTypes.GET_ORDERS_SUCCESS,
      payload: response.data.data
    });
  } catch (error) {
    apiErrorHandler(error, ActionTypes.GET_ORDERS_FAILED);
  }
}

export default function* () {
  yield takeLeading(ActionTypes.GET_ORDERS_PENDING, getOrders);
  yield takeLeading(ActionTypes.SELECT_PLAN, selectPlan);
  yield takeLeading(ActionTypes.SUBMIT_ORDER, submitOrder);
}