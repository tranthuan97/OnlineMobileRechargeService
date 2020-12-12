import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Form, Input, Button, Checkbox, Row } from 'antd';

import * as ActionTypes from '../../ActionTypes';

const layout = {
  labelCol: {
    span: 8,
  },
  wrapperCol: {
    span: 16,
  },
};
const tailLayout = {
  wrapperCol: {
    offset: 8,
    span: 16,
  },
};

const Login = () => {
  const dispatch = useDispatch();

  const loading = useSelector((reduxState) => reduxState.authState.loading);

  const [, forceUpdate] = React.useState();

  // To disable submit button at the beginning.
  React.useEffect(() => {
    forceUpdate({});
  }, []);

  const onFinish = (payload) => {
    if (payload.errorFields?.length > 0) return;

    dispatch({ type: ActionTypes.LOGIN_PENDING, payload });
  };

  const onFinishFailed = (errorInfo) => {
    console.log('Failed:', errorInfo);
  };

  return (
    <Row justify="center">
      <Form
        {...layout}
        name="basic"
        initialValues={{ remember: true }}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
      >
        {/* <Row justify="center" style={{ margin: '28px 0px' }}>
          <Image preview={false} src="/account-icon.png" />
        </Row> */}
        <Form.Item
          label="Phone"
          name="username"
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
          rules={[
            {
              required: true,
              message: 'Please input your password!',
            },
          ]}
        >
          <Input.Password />
        </Form.Item>

        <Form.Item {...tailLayout} name="remember" valuePropName="checked">
          <Checkbox>Remember me?</Checkbox>
        </Form.Item>

        <Form.Item {...tailLayout}>
          <Button
            type="primary"
            htmlType="submit"
            loading={loading}
            disabled={loading}
          >
            Sign In
        </Button>
        </Form.Item>
      </Form>

    </Row>
  );
};

export default Login;
