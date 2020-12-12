import { notification } from 'antd';
import { put, takeLeading } from 'redux-saga/effects';

import axios from '../utils/axios';
import { apiErrorHandler } from '../utils';
import * as ActionTypes from '../ActionTypes';

function* submitFeedback(action) {
  const { payload } = action;
  try {
    yield axios.post('/feedbacks', {
      fullname: payload.name,
      content: payload.messages,
    });

    notification.success({
      message: 'Success',
      description: 'Thank you for the feedback!'
    });

    yield new Promise((resolve) => setTimeout(resolve, 1500));

    yield put({ type: ActionTypes.SUBMIT_FEEDBACK_SUCCESS });
  } catch (error) {
    apiErrorHandler(error, ActionTypes.SUBMIT_FEEDBACK_FAILED);
  }
}

export default function* () {
  yield takeLeading(ActionTypes.SUBMIT_FEEDBACK, submitFeedback);
}