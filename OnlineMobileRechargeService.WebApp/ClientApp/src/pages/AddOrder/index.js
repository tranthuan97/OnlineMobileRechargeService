import React from 'react';
import { Container } from 'reactstrap';
import { useDispatch, useSelector } from 'react-redux';
import { Card, Divider, Image, Row, Typography } from 'antd';

import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';

const AddOrder = () => {
  const dispatch = useDispatch();

  const plans = useSelector((reduxState) => reduxState.orderState.plans)

  React.useEffect(() => {
    dispatch({ type: ActionTypes.GET_PLANS_PENDING })
  }, [dispatch]);

  const onClickItem = React.useCallback((item) => (e) => {
    dispatch({ type: ActionTypes.SELECT_PLAN, payload: item });
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
  }, [onClickItem])

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
    </div>
  );
}

export default AddOrder;
