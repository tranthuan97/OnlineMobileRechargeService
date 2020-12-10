import React from 'react';
import { Redirect } from 'react-router';
import { useSelector } from 'react-redux';
import { localStorageKey, routes } from '../../constants';
import Auth from '../../pages/Auth';

const AuthWrapper = ({ component }) => {
  const token = useSelector((state) => state.authState.token);

  const localStorageToken = localStorage.getItem(localStorageKey.TOKEN);

  if (!token || !localStorageToken) {
    return (
      <React.Fragment>
        <Redirect from="*" to={routes.Auth} />
        <Auth />
      </React.Fragment>
    );
  }

  return component;
};

export default AuthWrapper;