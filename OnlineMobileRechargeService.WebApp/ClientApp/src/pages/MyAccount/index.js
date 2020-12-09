import React from 'react';
import { UserOutlined } from '@ant-design/icons';
import { Col, Avatar, Typography, Card, Row, Divider, Form, Input, Button } from 'antd';

import styles from './styles.module.css';
import { useSelector } from 'react-redux';

const MyAccount = () => {
  const user = useSelector((reduxState) => reduxState.authState.user);
  console.log("🚀 ~ file: index.js ~ line 10 ~ MyAccount ~ user", user)

  const onClickAvatar = React.useCallback(() => {

  }, []);

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
          <Form layout="vertical">
            <Row justify="space-between">
              <Form.Item
                required
                name="firstname"
                label="First name"
                className={styles.formItem}
                initialValue={user.firstName}
              >
                <Input className={styles.input} />
              </Form.Item>
              <Form.Item
                required
                name="lastname"
                label="Last name"
                className={styles.formItem}
                initialValue={user.lastName}
              >
                <Input className={styles.input} />
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
                <Input className={styles.input} />
              </Form.Item>
              <Form.Item
                required
                name="address"
                label="Address"
                className={styles.formItem}
                initialValue={user.address}
              >
                <Input className={styles.input} />
              </Form.Item>
            </Row>
            <Divider />
            <Row justify="center">
              <Form.Item>
                <Button type="primary" className={styles.submitButton}>Save changes</Button>
              </Form.Item>
            </Row>
          </Form>
        </Card>
      </Col>
    </div>
  );
}

export default MyAccount;
