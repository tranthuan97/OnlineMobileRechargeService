import { notification } from 'antd';

import { store } from '..';
import * as ActionTypes from '../ActionTypes';

export const apiErrorHandler = (error, failedActionType) => {
  let unauthorized = false;

  let message = 'Something wrong';

  const dispatchModel = { type: failedActionType };

  if (error.response) {
    unauthorized = error.response.status === 401;
    if (error.response.data?.message) {
      message = error.response.data.message;
    } else {
      message = error.response.statusText;
    }
  } else {
    message = error.message;
  }

  notification.error({
    message: 'Error',
    description: message,
  });

  if (unauthorized) {
    dispatchModel.type = ActionTypes.LOGOUT_PENDING;
  }

  if (dispatchModel.type) {
    store.dispatch(dispatchModel);
  }
};