import React from 'react';
import { replace } from 'connected-react-router';
import { UserOutlined } from '@ant-design/icons';
import { useDispatch, useSelector } from 'react-redux';
import { Col, Avatar, Typography, Card, Row, Divider, Form, Input, Button } from 'antd';

import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';
import { routes } from '../../constants';

const ChangePassword = () => {
  const dispatch = useDispatch();

  const loading = useSelector((reduxState) => reduxState.authState.loading);

  const onFinish = React.useCallback((payload) => {
    dispatch({ type: ActionTypes.UPDATE_USER_PASSWORD_PENDING, payload });
  }, []);

  return (
    <div className={`${styles.container} ${styles.wrapper}`}>
      <Col span={16} offset={4} className={styles.container}>
        <Card className={styles.card}>
          <Typography.Title level={3}>Change Password</Typography.Title>
          <Row justify="center">
            <div>
              <Avatar size={128} icon={<UserOutlined />} style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }} />
            </div>
          </Row>
          <Divider />
          <Form
            name="basic"
            layout="vertical"
            onFinish={onFinish}
          >
            <Form.Item
              hasFeedback
              name="password"
              label="Current password"
              className={styles.formItem}
              rules={[{
                required: true,
                message: 'Current password is required'
              }]}
            >
              <Input.Password disabled={loading} className={styles.input} />
            </Form.Item>
            <Form.Item
              hasFeedback
              name="newPassword"
              label="New password"
              className={styles.formItem}
              rules={[{
                required: true,
                message: 'New password is required'
              }]}
            >
              <Input.Password disabled={loading} className={styles.input} />
            </Form.Item>
            <Form.Item
              hasFeedback
              name="confirmPassword"
              label="Confirm password"
              dependencies={['newPassword']}
              className={styles.formItem}
              rules={[{
                required: true,
                message: 'Confirm password is required'
              }, ({ getFieldValue }) => ({
                validator(rule, value) {
                  if (!value || getFieldValue('newPassword') === value) {
                    return Promise.resolve();
                  }
                  return Promise.reject('The two passwords that you entered do not match!');
                },
              })]}
            >
              <Input.Password disabled={loading} className={styles.input} />
            </Form.Item>
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
          </Form>
        </Card>
      </Col>
    </div>
  );
}

export default ChangePassword;
