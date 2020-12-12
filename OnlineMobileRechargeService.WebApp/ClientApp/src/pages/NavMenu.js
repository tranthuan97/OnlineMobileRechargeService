import React from 'react';
import { Image } from 'antd';
import { Link } from 'react-router-dom';
import { useDispatch, useSelector } from 'react-redux';
import {
  Button,
  Navbar,
  NavItem,
  NavLink,
  Collapse,
  Container,
  NavbarBrand,
  NavbarToggler,
} from 'reactstrap';

import FeedBack from './FeedBack';

import { routes } from '../constants';
import styles from './NavMenu.module.css';
import * as ActionTypes from '../ActionTypes';

const NavMenu = () => {
  const dispatch = useDispatch();

  const token = useSelector((state) => state.authState.token);

  const [state, setState] = React.useState({
    isOpen: false
  });

  const toggle = React.useCallback(() => {
    setState((prevState) => ({ ...prevState, isOpen: !prevState.isOpen }))
  }, []);

  const onLogout = React.useCallback(() => {
    dispatch({ type: ActionTypes.LOGOUT_PENDING });
  }, [dispatch]);

  const onClickFeedback = React.useCallback(() => {
    FeedBack.openModal();
  }, []);

  const isLoggedIn = token !== null;

  return (
    <header>
      <Navbar className={`${styles.boxShadow} navbar-expand-sm navbar-toggleable-sm border-bottom`} light>
        <Container>
          <NavbarBrand tag={Link} to={routes.Index}>
            <Image src="17910fbb516da033f97c.svg" preview={false} width={210} height={50} />
          </NavbarBrand>
          <NavbarToggler onClick={toggle} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={state.isOpen} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to={routes.PostBillPayment}>Post Bill Payment</NavLink>
              </NavItem>
              {!isLoggedIn && (
                <React.Fragment>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to={routes.Recharge}>Recharge</NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to={routes.Auth}>Login</NavLink>
                  </NavItem>
                </React.Fragment>
              )}
              <NavItem>
                <NavLink tag={Button} className={`${styles.buttonNoStyle} text-dark`} onClick={onClickFeedback}>Feedback</NavLink>
              </NavItem>
              {isLoggedIn && (
                <React.Fragment>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to={routes.Dashboard}>Dashboard</NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to={routes.Services}>Services</NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to={routes.MyAccount}>My Account</NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink tag={Button} className={`${styles.buttonNoStyle} text-dark`} onClick={onLogout}>Logout</NavLink>
                  </NavItem>
                </React.Fragment>
              )}
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
}

export default NavMenu;
