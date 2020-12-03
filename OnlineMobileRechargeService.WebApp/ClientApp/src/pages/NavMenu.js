import * as React from 'react';
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

import styles from './NavMenu.module.css';
import * as ActionTypes from '../ActionTypes';
import { routes } from '../constants';

const NavMenu = () => {
  const dispatch = useDispatch();

  const token = useSelector((state) => state.authState.token);

  const [state, setState] = React.useState({
    isOpen: false
  });

  const accountLink = token ? routes.Dashboard : routes.Auth;
  const accountButtonName = token ? 'Dashboard' : 'My Account';

  const toggle = React.useCallback(() => {
    setState((prevState) => ({ ...prevState, isOpen: !prevState.isOpen }))
  }, []);

  const onLogout = React.useCallback(() => {
    dispatch({ type: ActionTypes.LOGOUT_PENDING });
  }, [dispatch])

  return (
    <header>
      <Navbar className={`${styles.boxShadow} navbar-expand-sm navbar-toggleable-sm border-bottom`} light>
        <Container>
          <NavbarBrand tag={Link} to="/">
            <Image src="logo-dark.svg" preview={false} />
          </NavbarBrand>
          <NavbarToggler onClick={toggle} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={state.isOpen} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to={accountLink}>{accountButtonName}</NavLink>
              </NavItem>
              {token !== null && (
                <NavItem>
                  <NavLink tag={Button} className={`${styles.buttonNoStyle} text-dark`} onClick={onLogout}>Logout</NavLink>
                </NavItem>
              )}
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
}

export default NavMenu;
