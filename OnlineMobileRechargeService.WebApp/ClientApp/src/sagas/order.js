import { push } from "connected-react-router";
import { put, takeLeading } from "redux-saga/effects";

import { routes } from "../constants";
import * as ActionTypes from '../ActionTypes';

function* selectPlan() {
  yield put(push(routes.Payment));
}

function* submitOrder() {

}

export default function* () {
  yield takeLeading(ActionTypes.SELECT_PLAN, selectPlan);
  yield takeLeading(ActionTypes.SUBMIT_ORDER, submitOrder);
}