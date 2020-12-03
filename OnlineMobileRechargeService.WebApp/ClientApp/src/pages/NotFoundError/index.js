import { Row } from 'antd';
import React from 'react';

import styles from './styles.module.css';

const NotFoundError = () => {
  return (
    <Row align="middle" justify="center" className={styles.container}>Page Not Found</Row>
  );
}

export default NotFoundError;
