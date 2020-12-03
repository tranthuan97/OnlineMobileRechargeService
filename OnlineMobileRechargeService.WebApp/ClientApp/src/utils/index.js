export const apiErrorHandler = (error) => {
  let message = 'Something wrong';

  if (error.response) {
    message = error.response.data.message;
  } else if (error.request) {
    message = error.request._response;
  } else {
    message = error.message;
  }

  alert(message);
};