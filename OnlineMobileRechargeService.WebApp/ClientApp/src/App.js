import React from 'react';
import { Route } from 'react-router';
import { useDispatch } from 'react-redux';

import AuthWrapper from './components/AuthWrapper';

import Layout from './pages/Layout';

import Home from './pages/Home';
import Auth from './pages/Auth';
import Dashboard from './pages/Dashboard';
import NotFoundError from './pages/NotFoundError';

import { routes } from './constants';
import * as ActionTypes from './ActionTypes';

export default () => {
  const dispatch = useDispatch();

  React.useEffect(() => {
    dispatch({ type: ActionTypes.CHECK_LOCAL_STORAGE });
  }, [dispatch]);

  return (
    <Layout>
      <Route exact path={routes.Index} component={Home} />
      <Route
        path={routes.Auth}
        render={(props) => (
          <AuthWrapper
            childProps={props}
            component={<Auth {...props} />}
          />
        )}
      />
      <Route path={routes.Dashboard} component={(props) => (
        <AuthWrapper
          childProps={props}
          component={<Dashboard {...props} />}
        />
      )} />
      <Route path="*" component={NotFoundError} />
    </Layout>
  )
};
