import React from 'react';
import moment from 'moment';
import { Container } from 'reactstrap';
import { Row, Spin, Table, Typography } from 'antd';
import { useDispatch, useSelector } from 'react-redux';

import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';

const dataSource = [
  {
    key: '1',
    service: 'Mike',
    price: 32,
    note: '10 Downing Street',
    createdAt: moment().format('HH:mm DD/MM/YYYY'),
  },
  {
    key: '2',
    service: 'John',
    price: 42,
    note: '10 Downing Street',
    createdAt: moment().format('HH:mm DD/MM/YYYY'),
  },
];

const columns = [
  {
    key: 'key',
    title: 'Id',
    dataIndex: 'key',
  },
  {
    key: 'service',
    title: 'Service',
    dataIndex: 'service',
  },
  {
    key: 'price',
    title: 'Price',
    dataIndex: 'price',
  },
  {
    key: 'note',
    title: 'Note',
    dataIndex: 'note',
  },
  {
    key: 'createdAt',
    title: 'Created At',
    dataIndex: 'createdAt',
  },
];

const Dashboard = () => {
  const dispatch = useDispatch();

  const loading = useSelector((reduxState) => reduxState.authState.loading);

  React.useEffect(() => {
    dispatch({ type: ActionTypes.GET_USER_INFO_PENDING });
  }, [])


  return (
    <Container className={styles.container}>
      {/* {loading && <Spin />} */}
      <Row justify="space-between">
        <Typography.Title level={3}>My account</Typography.Title>
        <Typography.Title level={5}>Your email: davidbull931997@gmail.com</Typography.Title>
      </Row>
      <Row>
        <Typography.Title level={5}>My orders</Typography.Title>
      </Row>
      <Table
        pagination={false}
        columns={columns}
        dataSource={dataSource}
      />
    </Container>
  );
}

export default Dashboard;
