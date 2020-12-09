import React from 'react';
import { Form, Input, Button, Row } from 'antd';
import { useDispatch, useSelector } from 'react-redux';

import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';

const layout = {
  labelCol: {
    span: 10,
  },
  wrapperCol: {
    span: 24,
  },
};
const tailLayout = {
  wrapperCol: {
    offset: 8,
    span: 16,
  },
};

const Register = () => {
  const dispatch = useDispatch();

  const loading = useSelector((reduxState) => reduxState.authState.loading);
  console.log("🚀 ~ file: index.js ~ line 27 ~ Register ~ loading", loading)

  const [form] = Form.useForm();

  const [, forceUpdate] = React.useState();

  // To disable submit button at the beginning.
  React.useEffect(() => {
    forceUpdate({});
  }, []);

  const onFinish = (payload) => {
    if (payload.errorFields?.length > 0) return;

    dispatch({ type: ActionTypes.REGISTER_PENDING, payload });
  };

  const onFinishFailed = (errorInfo) => {
    console.log('Failed:', errorInfo);
  };

  return (
    <div className={styles.container}>
      <Form
        {...layout}
        name="basic"
        form={form}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
      >
        {/* <Row justify="center" style={{ margin: '28px 0px' }}>
          <Image preview={false} src="/account-icon.png" />
        </Row> */}
        <Form.Item
          label="Username"
          name="username"
          hasFeedback
          rules={[
            {
              required: true,
              message: 'Please input your username!',
            },
          ]}
        >
          <Input />
        </Form.Item>

        <Form.Item
          label="Password"
          name="password"
          hasFeedback
          rules={[
            {
              required: true,
              message: 'Please input your password!',
            },
          ]}
        >
          <Input.Password />
        </Form.Item>
        <Form.Item
          label="Confirm password"
          name="confirmPassword"
          hasFeedback
          rules={[
            {
              required: true,
              message: 'Please input your password!',
            },
          ]}
        >
          <Input.Password />
        </Form.Item>

        <Form.Item
          label="First name"
          name="firstname"
          hasFeedback
          rules={[
            {
              required: true,
              message: 'Please input your first name!',
            },
          ]}
        >
          <Input />
        </Form.Item>

        <Form.Item
          label="Last name"
          name="lastname"
          hasFeedback
          rules={[
            {
              required: true,
              message: 'Please input your first name!',
            },
          ]}
        >
          <Input />
        </Form.Item>

        <Form.Item
          label="Email"
          name="email"
          hasFeedback
          rules={[
            {
              required: true,
              message: 'Please input your email!',
            },
          ]}
        >
          <Input />
        </Form.Item>

        <Form.Item
          label="Address"
          name="address"
          hasFeedback
        >
          <Input />
        </Form.Item>

        <Form.Item {...tailLayout}>
          <Button
            type="primary"
            htmlType="submit"
            loading={loading}
            disabled={loading}
          >
            Sign Up
        </Button>
        </Form.Item>
      </Form>

    </div>
  );
};

export default Register;
