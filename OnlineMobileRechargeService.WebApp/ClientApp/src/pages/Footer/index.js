import React from 'react';
import { Col, Image, Row } from 'antd';
import { Container } from 'reactstrap';

import styles from './styles.module.css';
import { Link } from 'react-router-dom';

const Footer = () => {
  return (
    <div className={styles.container}>
      <Container>
        <Row>
          <Col flex={1}>
            <Image src="logo-light.svg" preview={false} />
          </Col>
          <Col flex={1} >
            <Row>
              <Link to="/" className={styles.link}>About Us</Link>
            </Row>
            <Row>
              <Link to="/" className={styles.link}>Payment methods</Link>
            </Row>
          </Col>
          <Col flex={1}>
            <Row>
              <Link to="/" className={styles.link}>Frequently asked questions</Link>
            </Row>
            <Row>
              <Link to="/" className={styles.link}>Safety</Link>
            </Row>
          </Col>
          <Col flex={1}>
            <Row>
              <Link to="/" className={styles.link}>Privacy policy</Link>
            </Row>
            <Row>
              <Link to="/" className={styles.link}>General conditions</Link>
            </Row>
            <Row>
              <Link to="/" className={styles.link}>Cookie statement</Link>
            </Row>
          </Col>
        </Row>
      </Container>
    </div>
  );
}

export default Footer;
