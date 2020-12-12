import React from 'react';
import { Container } from 'reactstrap';
import { PrinterFilled } from '@ant-design/icons';
import { useDispatch, useSelector } from 'react-redux';
import { Button, Card, Divider, Form, Image, Modal, Input, Row, Typography, notification } from 'antd';

import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';

const Recharge = () => {
  const dispatch = useDispatch();

  const plans = useSelector((reduxState) => reduxState.orderState.plans);

  const selectedPlan = useSelector((reduxState) => reduxState.orderState.selectedPlan);

  const [form] = Form.useForm();

  const [state, setState] = React.useState({
    modalVisible: false,
  });

  const toggleModal = React.useCallback((toggleValue) => {
    let modalVisible = toggleValue;

    if (typeof modalVisible !== 'boolean') {
      modalVisible = !state.modalVisible;
    }

    setState((prevState) => ({ ...prevState, modalVisible }));

  }, [state.modalVisible]);

  React.useEffect(() => {
    dispatch({ type: ActionTypes.GET_PLANS_PENDING })
  }, [dispatch]);

  React.useEffect(() => {
    const toggleValue = selectedPlan !== null
    toggleModal(toggleValue);

    if (!toggleValue) {
      form.resetFields();
    }
  }, [selectedPlan]);

  const onClickItem = React.useCallback((item) => (e) => {
    dispatch({ type: ActionTypes.PREPAID_SELECT_PLAN, payload: item });
  }, [dispatch]);

  const renderItem = React.useCallback((item, index) => {
    return (
      <div key={index} className={styles.cardContainer} onClick={onClickItem(item, index)}>
        <Card.Grid style={{ width: 'calc(100%/4)' }}>
          <Image src={item.provider?.logo} preview={false} />
          <Row justify="center">
            <Typography.Title level={4}>{`${item.name} - ${item.validate}`}</Typography.Title>
          </Row>
          <Row justify="center">
            <Typography.Title level={5}>{`${item.price} VND`}</Typography.Title>
          </Row>
          <Divider />
          <Row>
            <Typography.Text>{item.description}</Typography.Text>
          </Row>
        </Card.Grid>
      </div>
    )
  }, [onClickItem]);

  const onFinish = React.useCallback((values) => {
    dispatch({
      type: ActionTypes.SUBMIT_PREPAID_ORDER,
      payload: {
        ...values,
        ...state,
      },
    });
  }, [state, dispatch]);

  const onClickPrint = React.useCallback(() => {
    notification.success({
      message: 'Success',
      description: 'Printing bill successfully!',
    })
  }, [])

  const clearSelectedPlan = React.useCallback(() => {
    dispatch({ type: ActionTypes.PREPAID_SELECT_PLAN, payload: null })
  }, [dispatch])

  return (
    <div>
      <Row className={`${styles.background} ${styles.separator}`}>
        <Container>
          <Row style={{ justifyContent: 'center' }}>
            <Typography.Title style={{ color: 'whitesmoke' }}>Worldwide mobile recharge: send credit and data to any phone</Typography.Title>
          </Row>
        </Container>
      </Row>
      <Row className={styles.separator}>
        <Container>
          <Typography.Text level={5} >Recharge Mobifone Vietnam online at Recharge. Get an easy recharge for your or someone else’s phone credit or data, worldwide. Fill in your number, it will be recharged automatically with the amount of your choice. Support your loved ones the easy way!</Typography.Text>
        </Container>
      </Row>
      <Row justify="center">
        <Container>
          <Card title="Plans">
            {plans.map(renderItem)}
          </Card>
        </Container>
      </Row>
      <Modal
        width="40%"
        footer={null}
        closable={false}
        onCancel={toggleModal}
        afterClose={clearSelectedPlan}
        visible={state.modalVisible}
      >
        <Form
          form={form}
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
                  {/* <Row className={styles.mb10}>
                      <Typography.Text>{user.username}</Typography.Text>
                    </Row> */}
                  <Row className={styles.mb10}>
                    <Typography.Text>{selectedPlan?.description}</Typography.Text>
                  </Row>
                </div>
              </Row>
              <Divider />
              <Row justify="space-between">
                <Typography.Text strong className={styles.title}>{selectedPlan?.name} - {selectedPlan?.validate}</Typography.Text>
                <Typography.Text strong className={styles.title}>{selectedPlan?.price}</Typography.Text>
              </Row>
              <Row justify="space-between">
                <Typography.Text>Service fee</Typography.Text>
                {/* <Typography.Text>{selectedPlan?.price}</Typography.Text> */}
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
                <Typography.Title level={5}>Choose a payment method</Typography.Title>
              </Row>
              <Row className={styles.mb10}>
                <Typography.Text>Thanks to our secure 256-bit SSL connection it's completely safe to pay!</Typography.Text>
              </Row>
              <Row>
                <Card.Grid className={styles.cardGrid} onClick={onClickPaymentMethod}>
                  <Image src="/visa.jpg" preview={false} className={styles.methodImage} />
                </Card.Grid>
                <Card.Grid className={styles.cardGrid} onClick={onClickPaymentMethod}>
                  <Image src="/mastercard.png" preview={false} className={styles.methodImage} />
                </Card.Grid>
                <Card.Grid className={styles.cardGrid} onClick={onClickPaymentMethod}>
                  <Image src="/paypal.png" preview={false} className={styles.methodImage} />
                </Card.Grid>
              </Row>
            </Card>
          </Row> */}
          <Row className={styles.mb10}>
            <Card className={styles.fitCard}>
              <Row className={styles.mb10}>
                <Typography.Title level={5}>Fill in the required details</Typography.Title>
              </Row>
              <Row className={styles.mb10}>
                <Typography.Text>With these details, we can provide a secure payment.</Typography.Text>
              </Row>
              <Row>
                <div className={styles.fitCard}>
                  <Row justify="center">
                    <Form.Item
                      name="phone"
                      label="Phone"
                      className={styles.fitCard}
                      rules={[{ required: true, message: 'Phone is required' }]}
                    >
                      <Input disabled={selectedPlan?.paymented} />
                    </Form.Item>
                  </Row>
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
                      >
                        <Input disabled={selectedPlan?.paymented} placeholder="Your first name" />
                      </Form.Item>
                    </div>
                    <div style={{ width: 'calc(50% - 8px)', margin: '0 8px' }}>
                      <Form.Item
                        name="lastname"
                        label="Last name"
                        rules={[{ required: true, message: 'Last name is required' }]}
                      >
                        <Input disabled={selectedPlan?.paymented} placeholder="Your first name" />
                      </Form.Item>
                    </div>
                  </Row>
                  {!selectedPlan?.paymented && (
                    <Row justify="center">
                      <Form.Item className={styles.fitCard}>
                        <Button block size="large" type="primary" htmlType="submit">
                          Recharge
                      </Button>
                      </Form.Item>
                    </Row>
                  )}
                  {selectedPlan?.paymented && (
                    <Row justify="center">
                      <Form.Item className={styles.fitCard}>
                        <Button
                          block
                          size="large"
                          type="primary"
                          htmlType="button"
                          icon={<PrinterFilled />}
                          onClick={onClickPrint}
                        >
                          PRINT
                        </Button>
                      </Form.Item>
                    </Row>
                  )}

                  <Row justify="center">
                    <Form.Item className={styles.fitCard}>
                      <Button block size="large" onClick={toggleModal}>
                        Close
                      </Button>
                    </Form.Item>
                  </Row>
                </div>
              </Row>
            </Card>
          </Row>
        </Form>
      </Modal>
    </div>
  );
}

export default Recharge;
