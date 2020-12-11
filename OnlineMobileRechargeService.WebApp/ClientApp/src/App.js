import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {
  Route,
  Switch,
} from 'react-router-dom';

import AuthWrapper from './components/AuthWrapper';

import Layout from './pages/Layout';

import Home from './pages/Home';
import Auth from './pages/Auth';
import Dashboard from './pages/Dashboard';
import MyAccount from './pages/MyAccount';
import ChangePassword from './pages/ChangePassword';
import AddOrder from './pages/AddOrder';
import Payment from './pages/Payment';
import NotFoundError from './pages/NotFoundError';

import { routes } from './constants';
import * as ActionTypes from './ActionTypes';
import AboutUs from './pages/AboutUs';

export default () => {
  const dispatch = useDispatch();

  const ready = useSelector((state) => state.authState.ready);

  React.useEffect(() => {
    dispatch({ type: ActionTypes.CHECK_LOCAL_STORAGE });
  }, [dispatch]);

  if (!ready) {
    return null;
  }

  return (
    <Layout>
      <Switch>
        <Route exact path={routes.Index} component={Home} />
        <Route exact path={routes.AboutUs} component={AboutUs} />
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

        <Route path={routes.MyAccount} component={(props) => (
          <AuthWrapper
            childProps={props}
            component={<MyAccount {...props} />}
          />
        )} />

        <Route path={routes.ChangePassword} component={(props) => (
          <AuthWrapper
            childProps={props}
            component={<ChangePassword {...props} />}
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
  );
};
