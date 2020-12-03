import React from 'react';
import { Card, Row, Tabs } from 'antd';

import Login from '../Login';
import Register from '../Register';

import styles from './styles.module.css';

const Auth = () => {
  return (
    <Row align="middle" justify="center" className={styles.container}>
      <Card>
        <Tabs defaultActiveKey="1" centered>
          <Tabs.TabPane tab="Login" key="1">
            <Login />
          </Tabs.TabPane>
          <Tabs.TabPane tab="Register" key="2">
            <Register />
          </Tabs.TabPane>
        </Tabs>
      </Card>
    </Row>
  );
}

export default Auth;
