import React from 'react';
import { replace } from 'connected-react-router';
import { UserOutlined } from '@ant-design/icons';
import { useDispatch, useSelector } from 'react-redux';
import { Col, Avatar, Typography, Card, Row, Divider, Form, Input, Button } from 'antd';

import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';
import { routes } from '../../constants';

const MyAccount = () => {
  const dispatch = useDispatch();

  const user = useSelector((reduxState) => reduxState.authState.user);

  const loading = useSelector((reduxState) => reduxState.authState.loading);

  const onClickAvatar = React.useCallback(() => {

  }, []);

  const onFinish = React.useCallback((payload) => {
    dispatch({ type: ActionTypes.SET_USER_INFO_PENDING, payload });
  }, []);

  const onClickChangePassword = React.useCallback(() => {
    dispatch(replace(routes.ChangePassword))
  }, [])

  return (
    <div className={`${styles.container} ${styles.wrapper}`}>
      <Col span={16} offset={4} className={styles.container}>
        <Card className={styles.card}>
          <Typography.Title level={3}>Account</Typography.Title>
          <Row justify="center">
            <div className={styles.pointer} onClick={onClickAvatar}>
              <Avatar size={128} icon={<UserOutlined />} style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }} />
            </div>
          </Row>
          <Divider />
          <Form
            name="basic"
            layout="vertical"
            onFinish={onFinish}
          >
            <Row justify="space-between">
              <Form.Item
                required
                name="firstname"
                label="First name"
                className={styles.formItem}
                initialValue={user.firstName}
              >
                <Input disabled={loading} className={styles.input} />
              </Form.Item>
              <Form.Item
                required
                name="lastname"
                label="Last name"
                className={styles.formItem}
                initialValue={user.lastName}
              >
                <Input disabled={loading} className={styles.input} />
              </Form.Item>
            </Row>
            <Row justify="space-between">
              <Form.Item
                required
                name="email"
                label="Email"
                initialValue={user.email}
                className={styles.formItem}
              >
                <Input disabled={loading} className={styles.input} />
              </Form.Item>
              <Form.Item
                required
                name="address"
                label="Address"
                className={styles.formItem}
                initialValue={user.address}
              >
                <Input disabled={loading} className={styles.input} />
              </Form.Item>
            </Row>
            <Row justify="center">
              <Form.Item>
                <Button
                  type="primary"
                  htmlType="submit"
                  loading={loading}
                  disabled={loading}
                  className={styles.submitButton}
                >
                  Save changes
                </Button>
              </Form.Item>
            </Row>
            <Divider />
            <Row justify="center">
              <Button
                type="primary"
                htmlType="button"
                disabled={loading}
                className={styles.submitButton}
                onClick={onClickChangePassword}
              >
                Change password
                </Button>
            </Row>
          </Form>
        </Card>
      </Col>
    </div>
  );
}

export default MyAccount;
