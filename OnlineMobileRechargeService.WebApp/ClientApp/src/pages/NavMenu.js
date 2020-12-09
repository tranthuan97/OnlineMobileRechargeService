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
            <Image src="17910fbb516da033f97c.svg" preview={false} width={210} height={50} />
          </NavbarBrand>
          <NavbarToggler onClick={toggle} className="mr-2" />
          <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={state.isOpen} navbar>
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
              </NavItem>
              {token === null && (
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to={routes.Auth}>Login</NavLink>
                </NavItem>
              )}
              {token !== null && (
                <React.Fragment>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to={routes.Dashboard}>Dashboard</NavLink>
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
