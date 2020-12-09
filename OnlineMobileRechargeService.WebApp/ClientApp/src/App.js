import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {
  Route,
  Switch,
  BrowserRouter as Router,
} from 'react-router-dom';

import AuthWrapper from './components/AuthWrapper';

import Layout from './pages/Layout';

import Home from './pages/Home';
import Auth from './pages/Auth';
import Dashboard from './pages/Dashboard';
import MyAccount from './pages/MyAccount';
import AddOrder from './pages/AddOrder';
import Payment from './pages/Payment';
import NotFoundError from './pages/NotFoundError';

import { routes } from './constants';
import * as ActionTypes from './ActionTypes';

export default () => {
  const dispatch = useDispatch();

  const ready = useSelector((state) => state.authState.ready);

  React.useEffect(() => {
    dispatch({ type: ActionTypes.CHECK_LOCAL_STORAGE });
  }, []);

  if (!ready) return null;

  return (
    <React.Suspense>
      <Layout>
        <Switch>
          <Route exact path={routes.Index} component={Home} />
          <Route
            path={routes.Auth}
            component={(props) => (
              <AuthWrapper
                childProps={props}
                component={<Auth {...props} />}
              />
            )}
          />
          <Route exact path={routes.Dashboard} component={(props) => (
            <AuthWrapper
              childProps={props}
              component={<Dashboard {...props} />}
            />
          )} />

          <Route exact path={routes.MyAccount} component={(props) => (
            <AuthWrapper
              childProps={props}
              component={<MyAccount {...props} />}
            />
          )} />

          {/* PAYMENT */}
          <Route path={routes.AddOrder} component={(props) => (
            <AuthWrapper
              childProps={props}
              component={<AddOrder {...props} />}
            />
          )} />
          <Route path={routes.Payment} component={(props) => (
            <AuthWrapper
              childProps={props}
              component={<Payment {...props} />}
            />
          )} />
          <Route path="*" component={NotFoundError} />
        </Switch>
      </Layout>
    </React.Suspense>
  );
};
