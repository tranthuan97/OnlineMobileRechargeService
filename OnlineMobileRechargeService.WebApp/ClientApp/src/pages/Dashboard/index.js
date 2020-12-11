import React from 'react';
import moment from 'moment';
import { Container } from 'reactstrap';
import { useHistory } from 'react-router';
import { PlusCircleOutlined } from '@ant-design/icons';
import { Button, Row, Table, Typography } from 'antd';
import { useDispatch, useSelector } from 'react-redux';

import { routes } from '../../constants';
import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';

const columns = [
  {
    key: 'key',
    title: 'Id',
    dataIndex: 'id',
  },
  {
    key: 'service',
    title: 'Service',
    // dataIndex: 'service',
    render: (text, record) => {
      return `${record.vas.name} - ${record.provider.name}`;
    }
  },
  {
    key: 'price',
    title: 'Price',
    dataIndex: 'price',
  },
  {
    key: 'payment-card',
    title: 'Payment Card',
    // dataIndex: 'note',
    render: (text, record) => {
      return record.paymentCard;
    }
  },
  {
    key: 'note',
    title: 'Note',
    // dataIndex: 'note',
    render: (text, record) => {
      return record.simType;
    }
  },
  {
    key: 'createdAt',
    title: 'Created At',
    // dataIndex: 'createdDate',
    render: (text) => {
      return moment(text).format('DD/MM/YYYY HH:mm');
    }
  },
];

const Dashboard = () => {
  const history = useHistory();

  const dispatch = useDispatch();

  const user = useSelector((reduxState) => reduxState.authState.user);

  const transactions = useSelector((reduxState) => reduxState.transactionState.transactions);

  React.useEffect(() => {
    dispatch({ type: ActionTypes.GET_USER_TRANSACTIONS_PENDING });
  }, [dispatch]);

  const onClickOrder = React.useCallback(() => {
    history.push(routes.AddOrder);
  }, [history]);

  return (
    <Container className={styles.container}>
      {/* {loading && <Spin />} */}
      <Row justify="space-between">
        <Typography.Title level={3}>My account</Typography.Title>
        <div>
          <Typography.Title level={5}>{`Your phone: ${user.username}`}</Typography.Title>
          <Button
            type="primary"
            onClick={onClickOrder}
            style={{ alignItems: 'center', justifyContent: 'center' }}
            icon={<PlusCircleOutlined style={{ fontSize: 24, verticalAlign: 'middle', lineHeight: 0 }} />}
          >
            Add order
          </Button>
        </div>
      </Row>
      <Row>
        <Typography.Title level={5}>My orders</Typography.Title>
      </Row>
      <Table
        columns={columns}
        pagination={false}
        dataSource={transactions}
        rowKey={(record) => record.id.toString()}
      />
    </Container >
  );
}

export default Dashboard;
