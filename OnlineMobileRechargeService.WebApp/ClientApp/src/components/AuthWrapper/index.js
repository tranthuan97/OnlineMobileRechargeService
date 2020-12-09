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

  const isDashboard = to.includes(routes.Dashboard);

  if (isDashboard === false) {
    to = routes.Dashboard;
  }

  return component;
};

export default AuthWrapper;