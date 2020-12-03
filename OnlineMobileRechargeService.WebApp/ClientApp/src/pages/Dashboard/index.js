import React from 'react';
import { Col, Row, Spin } from 'antd';
import { useDispatch, useSelector } from 'react-redux';

import styles from './styles.module.css';
import * as ActionTypes from '../../ActionTypes';

const Dashboard = () => {
  const dispatch = useDispatch();

  const loading = useSelector((reduxState) => reduxState.authState.loading);

  React.useEffect(() => {
    dispatch({ type: ActionTypes.GET_USER_INFO_PENDING });
  }, [])


  return (
    <Col className={styles.container}>
      {loading && <Spin />}
      <Row>

      </Row>
    </Col>
  );
}

export default Dashboard;
