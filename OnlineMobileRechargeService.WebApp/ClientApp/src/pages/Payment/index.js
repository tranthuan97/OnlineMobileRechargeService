import React from 'react';
import { FiSmartphone } from "react-icons/fi";
import { useDispatch, useSelector } from 'react-redux';
import { Card, Col, Row, Typography, Image, Divider, Input, Form, Button, Select } from 'antd';

import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';

const Payment = () => {
  const dispatch = useDispatch();

  const selectedPlan = useSelector((reduxState) => reduxState.orderState.selectedPlan);

  const user = useSelector((reduxState) => reduxState.authState.user);

  const [state, setState] = React.useState({
    email: '',
    detailVisible: null,
    selectedPaymentMethod: 'Prepaid',
  });

  const onClickPaymentAccount = React.useCallback((imageSource) => () => {
    setState((prevState) => ({ ...prevState, detailVisible: imageSource }));
    setTimeout(() => {
      window.scrollTo({ top: 9999, behavior: 'smooth' });
    }, 250);
  }, [])

  const onFinish = React.useCallback((values) => {
    dispatch({
      type: ActionTypes.SUBMIT_ORDER,
      payload: {
        ...values,
        ...state,
      },
    });
  }, [state, dispatch]);

  return (
    <div className={styles.container}>
      <Col span={16} offset={4}>
        <Form
          layout="vertical"
          onFinish={onFinish}
          className={styles.fitCard}
        >
          <Row className={styles.mb10}>
            <Card className={styles.fitCard}>
              <Row>
                <Image
                  src={selectedPlan?.provider?.logo}
                  preview={false}
                  width={180}
                  height={114}
                  wrapperClassName={styles.mr10}
                />

                <div>
                  <Typography.Title level={5}>{selectedPlan?.provider?.name}</Typography.Title>
                  {/* <Row>
                    <Typography.Text>Vietnam</Typography.Text>
                  </Row> */}
                  <Row className={styles.mb10}>
                    <Typography.Text>{user.username}</Typography.Text>
                  </Row>
                  <Row className={styles.mb10}>
                    <FiSmartphone fontSize={24} className={styles.mr10} /><Typography.Text>The phone credit will be put on the phone immediately</Typography.Text>
                  </Row>
                </div>
              </Row>
              <Divider />
              <Row justify="space-between">
                <Typography.Text strong className={styles.title}>{selectedPlan?.provider?.name}</Typography.Text>
                <Typography.Text strong className={styles.title}>{selectedPlan?.price}</Typography.Text>
              </Row>
              <Row justify="space-between">
                <Typography.Text>Service fee</Typography.Text>
                <Typography.Text>{selectedPlan?.price}</Typography.Text>
              </Row>
              <Divider />
              <Row justify="space-between">
                <Typography.Text strong className={styles.title}>Total</Typography.Text>
                <Typography.Text strong className={styles.title}>{selectedPlan?.price}</Typography.Text>
              </Row>
            </Card>
          </Row>
          {/* <Row className={styles.mb10}>
            <Card className={styles.fitCard}>
              <Row className={styles.mb10}>
                <Typography.Title level={5}>Fill in your email address*</Typography.Title>
              </Row>
              <Row className={styles.mb10}>
                <Typography.Text>This way we can keep you updated on the order status</Typography.Text>
              </Row>
              <Row>
                <Form.Item name="email">
                  <Input
                    size="large"
                    placeholder="Your Email*"
                  />
                </Form.Item>
              </Row>
            </Card>
          </Row> */}
          <Row className={styles.mb10}>
            <Card className={styles.fitCard}>
              <Row className={styles.mb10}>
                <Typography.Title level={5}>Choose a payment method</Typography.Title>
              </Row>
              <Row className={styles.mb10}>
                <Typography.Text>Thanks to our secure 256-bit SSL connection it's completely safe to pay!</Typography.Text>
              </Row>
              <Row>
                <Card.Grid className={styles.cardGrid} onClick={onClickPaymentAccount('/visa.jpg')}>
                  <Image src="/visa.jpg" preview={false} className={styles.methodImage} />
                </Card.Grid>
                <Card.Grid className={styles.cardGrid} onClick={onClickPaymentAccount('/mastercard.png')}>
                  <Image src="/mastercard.png" preview={false} className={styles.methodImage} />
                </Card.Grid>
                <Card.Grid className={styles.cardGrid} onClick={onClickPaymentAccount('/paypal.png')}>
                  <Image src="/paypal.png" preview={false} className={styles.methodImage} />
                </Card.Grid>
              </Row>
            </Card>
          </Row>
          {state.detailVisible !== null && (
            <Row className={styles.mb10}>
              <Card className={styles.fitCard}>
                <Row justify="space-between" className={styles.mb10}>
                  <Typography.Title level={5}>Fill in the required details</Typography.Title>
                  <Image width={128} src={state.detailVisible} preview={false} />
                </Row>
                <Row className={styles.mb10}>
                  <Typography.Text>With these details, we can provide a secure payment.</Typography.Text>
                </Row>
                <Row>
                  <Form.Item
                    label="Payment Method"
                    name="paymentMethod"
                    initialValue="PREPAID"
                  >
                    <Select>
                      <Select.Option value="PREPAID">Prepaid</Select.Option>
                      <Select.Option value="POSTPAID">Postpaid</Select.Option>
                    </Select>
                  </Form.Item>
                </Row>
                <Row>
                  <div className={styles.fitCard}>
                    <Row justify="center">
                      <Form.Item
                        name="paymentCard"
                        label="Payment Card"
                        className={styles.fitCard}
                        rules={[{ required: true, message: 'Payment card is required' }]}
                      >
                        <Input disabled={selectedPlan?.paymented} />
                      </Form.Item>
                    </Row>
                    <Row>
                      <div style={{ width: 'calc(50% - 8px)' }}>
                        <Form.Item
                          name="firstname"
                          label="First name"
                          rules={[{ required: true, message: 'First name is required' }]}
                          initialValue={user.firstName}
                        >
                          <Input disabled={selectedPlan?.paymented} placeholder="Your first name" />
                        </Form.Item>
                      </div>
                      <div style={{ width: 'calc(50% - 8px)', margin: '0 8px' }}>
                        <Form.Item
                          name="lastname"
                          label="Last name"
                          rules={[{ required: true, message: 'Last name is required' }]}
                          initialValue={user.lastName}
                        >
                          <Input disabled={selectedPlan?.paymented} placeholder="Your first name" />
                        </Form.Item>
                      </div>
                    </Row>
                    <Row justify="center">
                      <Form.Item className={styles.fitCard}>
                        <Button block size="large" type="primary" htmlType="submit">
                          Recharge
                      </Button>
                      </Form.Item>
                    </Row>
                  </div>
                </Row>

              </Card>
            </Row>
          )}
        </Form>
      </Col>
    </div >
  );
}

export default Payment;
