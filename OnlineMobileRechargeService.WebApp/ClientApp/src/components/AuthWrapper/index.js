import React from 'react';
import { Redirect } from 'react-router';
import { useSelector } from 'react-redux';
import { routes } from '../../constants';

const AuthWrapper = ({ childProps, component }) => {
  const { pathname, search } = childProps.location;

  const token = useSelector((state) => state.authState.token);

  let to = pathname + search;

  if (token === null) {
    return (
      <React.Fragment>
        <Redirect from="*" to={routes.Auth} />
        {component}
      </React.Fragment>
    );
  }

  if (to.includes('/dashboard') === false) {
    to = '/dashboard';
  }

  return (
    <React.Fragment>
      {component}
      <Redirect to={to} />
    </React.Fragment>
  );
};

export default AuthWrapper;