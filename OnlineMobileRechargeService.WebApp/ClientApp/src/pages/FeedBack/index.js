import React from 'react';
import { UserOutlined } from '@ant-design/icons';
import { useDispatch, useSelector } from 'react-redux';
import { Form, Input, Modal, Row, Typography } from 'antd';

import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';

let openModal;

const FeedBack = () => {
  const [form] = Form.useForm();

  const dispatch = useDispatch();

  const loading = useSelector((reduxState) => reduxState.feedbackState.loading);
  const isSuccess = useSelector((reduxState) => reduxState.feedbackState.isSuccess);

  const [state, setState] = React.useState({
    visible: false,
  });

  React.useEffect(() => {
    if (isSuccess) {
      toggleModal();
      form.resetFields();
    }
  }, [isSuccess])

  const toggleModal = React.useCallback(() => {
    setState((prevState) => ({
      ...prevState,
      visible: !prevState.visible
    }))
  }, []);

  const onFinish = React.useCallback((values) => {
    dispatch({ type: ActionTypes.SUBMIT_FEEDBACK, payload: values })
  }, [dispatch])

  openModal = toggleModal;

  return (
    <Modal
      width="50%"
      title="Feedback"
      closable={false}
      confirmLoading={loading}
      onOk={() => form.submit()}
      onCancel={!loading && toggleModal}
      visible={state.visible}
    >
      <div className={styles.container}>
        <Form form={form} onFinish={onFinish}>
          <Row className={styles.mb30}>
            <Typography.Text className={styles.title}>
              Thank you for the feedback, leave it to below!
            </Typography.Text>
          </Row>
          <Form.Item name="name">
            <Input
              size="large"
              bordered={false}
              disabled={loading}
              placeholder="Name"
              className={styles.underline}
              prefix={<UserOutlined className={styles.mr10} />}
            />
          </Form.Item>
          {/* <Form.Item name="email">
            <Input
              size="large"
              bordered={false}
              placeholder="E-mail"
              className={styles.underline}
              prefix={<MailOutlined className={styles.mr10} />}
            />
          </Form.Item> */}
          <Form.Item name="messages">
            <Input.TextArea
              rows={4}
              disabled={loading}
              placeholder="Messages"
            />
          </Form.Item>
        </Form>
      </div>
    </Modal>
  );
}

FeedBack.openModal = () => {
  openModal();
};

export default FeedBack;
