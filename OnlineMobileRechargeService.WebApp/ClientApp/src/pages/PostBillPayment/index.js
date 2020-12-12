import React from 'react';
import { Button, Card, Form, Image, Input, notification, Row, Typography } from 'antd';

import styles from './styles.module.css';

const PostBillPayment = () => {
  const [form] = Form.useForm();

  const [state, setState] = React.useState({
    loading: false,
    selectedPlan: null
  });

  const onFinish = React.useCallback(() => {
    setState((prevState) => ({ ...prevState, loading: true }))
  }, []);

  React.useEffect(() => {
    if (state.loading) {
      setTimeout(() => {
        notification.success({
          message: 'Success',
          description: 'Post bill payment successfully!',
        });
        form.resetFields();
        setState((prevState) => ({ ...prevState, loading: false }))
      }, 1000);
    }
  }, [state.loading]);

  const onClickPaymentMethod = React.useCallback((imageSource) => () => {
    setState((prevState) => ({
      ...prevState,
      selectedPlan: {
        ...prevState.selectedPlan,
        method: imageSource,
      },
    }));
  }, [])

  return (
    <Row justify="center" className={styles.container}>
      <Form

        form={form}
        style={{ width: '40%' }}
        layout="vertical"
        onFinish={onFinish}
      >
        <Row className={styles.mb10}>
          <Card className={styles.fitCard}>
            <Row className={styles.mb10}>
              <Typography.Title level={5}>Choose a payment method</Typography.Title>
            </Row>
            <Row className={styles.mb10}>
              <Typography.Text>Thanks to our secure 256-bit SSL connection it's completely safe to pay!</Typography.Text>
            </Row>
            <Row>
              <Card.Grid className={styles.cardGrid} onClick={onClickPaymentMethod('/visa.jpg')}>
                <Image src="/visa.jpg" preview={false} className={styles.methodImage} />
              </Card.Grid>
              <Card.Grid className={styles.cardGrid} onClick={onClickPaymentMethod('/mastercard.png')}>
                <Image src="/mastercard.png" preview={false} className={styles.methodImage} />
              </Card.Grid>
              <Card.Grid className={styles.cardGrid} onClick={onClickPaymentMethod('/paypal.png')}>
                <Image src="/paypal.png" preview={false} className={styles.methodImage} />
              </Card.Grid>
            </Row>
          </Card>
        </Row>
        <Row className={styles.mb10}>
          <Card className={styles.fitCard}>
            <Row className={styles.mb10} justify="space-between">
              <Typography.Title level={5}>Fill in the required details</Typography.Title>
              <Image width={128} src={state.selectedPlan?.method} preview={false} />
            </Row>
            <Row className={styles.mb10}>
              <Typography.Text>With these details, we can provide a secure payment.</Typography.Text>
            </Row>
            <Row>
              <div className={styles.fitCard}>
                <Row justify="center">
                  <Form.Item
                    name="phone"
                    label="Post Bill Phone"
                    className={styles.fitCard}
                    rules={[{ required: true, message: 'Phone is required' }]}
                  >
                    <Input disabled={state.loading || !state.selectedPlan?.method} />
                  </Form.Item>
                </Row>
                <Row justify="center">
                  <Form.Item
                    name="paymentCard"
                    label="Payment Card"
                    className={styles.fitCard}
                    rules={[{ required: true, message: 'Payment card is required' }]}
                  >
                    <Input
                      disabled={state.loading || !state.selectedPlan?.method}
                    />
                  </Form.Item>
                </Row>
                <Row>
                  <div style={{ width: 'calc(50% - 8px)' }}>
                    <Form.Item
                      name="firstname"
                      label="First name"
                      rules={[{ required: true, message: 'First name is required' }]}
                    >
                      <Input
                        disabled={state.loading || !state.selectedPlan?.method}
                        placeholder="Your first name"
                      />
                    </Form.Item>
                  </div>
                  <div style={{ width: 'calc(50% - 8px)', margin: '0 8px' }}>
                    <Form.Item
                      name="lastname"
                      label="Last name"
                      rules={[{ required: true, message: 'Last name is required' }]}
                    >
                      <Input
                        disabled={state.loading || !state.selectedPlan?.method}
                        placeholder="Your first name"
                      />
                    </Form.Item>
                  </div>
                </Row>
                <Row justify="center">
                  <Form.Item className={styles.fitCard}>
                    <Button
                      block
                      size="large"
                      type="primary"
                      htmlType="submit"
                      loading={state.loading}
                      disabled={state.loading || !state.selectedPlan?.method}
                    >
                      Pay the bill
                    </Button>
                  </Form.Item>
                </Row>
              </div>
            </Row>
          </Card>
        </Row>
      </Form>
    </Row>
  );
}

export default PostBillPayment;
