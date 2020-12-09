import React from 'react';
import { Container } from 'reactstrap';
import { useDispatch } from 'react-redux';
import { Button, Card, Image, Row, Typography } from 'antd';

import axios from '../../utils/axios';
import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';

const AddOrder = () => {
  const dispatch = useDispatch();

  React.useEffect(() => {
    axios.get('/plans')
      .then((response) => {
        console.log("🚀 ~ file: index.js ~ line 12 ~ .then ~ response", response)
      })
      .catch((error) => {
        console.log("🚀 ~ file: index.js ~ line 15 ~ React.useEffect ~ error", { ...error })

      });
  }, []);

  const onClickItem = React.useCallback((item) => (e) => {
    dispatch({ type: ActionTypes.SELECT_PLAN, payload: item });
  }, [])

  const renderItem = React.useCallback((item, index) => {
    return (
      <div key={index} className={styles.cardContainer} onClick={onClickItem(item, index)}>
        <Card.Grid className={styles.card}>
          <Image src={item.providerImage} preview={false} />
          <Typography.Title level={3}>
            {item.provider}
          </Typography.Title>
          <Typography.Text>
            {`Receive ${item.price} VND`}
          </Typography.Text>
        </Card.Grid>
      </div>
    )
  }, [])

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
            {Array(8).fill({
              provider: 'Mobifone',
              price: 20000.00,
              providerImage: '/mobifone_vietnam.jpg',
            }).map(renderItem)}
          </Card>
        </Container>
      </Row>
    </div>
  );
}

export default AddOrder;
