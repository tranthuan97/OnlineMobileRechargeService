import React from 'react';
import { Col, Image, Row } from 'antd';
import { Container } from 'reactstrap';
import { Link } from 'react-router-dom';

import styles from './styles.module.css';
import { routes } from '../../constants';

const Footer = () => {
  return (
    <footer className={styles.container}>
      <Container>
        <Row>
          <Col flex={1}>
            <Image src="17910fbb516da033f97c.svg" preview={false} width={210} height={50} />
          </Col>
          <Col flex={1} >
            <Row>
              <Link to={routes.AboutUs} className={styles.link}>About Us</Link>
            </Row>
            {/* <Row>
              <Link to="/" className={styles.link}>Payment methods</Link>
            </Row> */}
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
    </footer>
  );
}

export default Footer;
