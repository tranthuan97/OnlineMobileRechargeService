import * as React from 'react';
import { Container } from 'reactstrap';
import { Typography, Row, Col } from 'antd';

import styles from './styles.module.css';

const AboutUs = () => {
  return (
    <div className={styles.container}>
      <div className={styles.background}>
        <Container>
          <Row style={{ justifyContent: 'center' }}>
            <Typography.Title style={{ color: 'whitesmoke' }}>About Us</Typography.Title>
            {/* <Dropdown overlay={dropdownList} trigger={['click']}>
              <Button size="large" className="ant-dropdown-link">
                {state.selectedCountry.dial_code} {state.selectedCountry.name}<DownOutlined />
              </Button>
            </Dropdown> */}
          </Row>
        </Container>
      </div>
      <Row>
        <Col span={16} offset={4} className={styles.contentContainer}>
          <Row>
            <Typography.Title level={4}>TyP have joined forces.</Typography.Title>
          </Row>
          <Row className={styles.mb10}>
            <Typography.Text className={styles.contentText}>
              {`You know TyP as the go-to place for international mobile top-up. Or Rapido.com as the comprehensive store for prepaid digital codes. Now, all your favourite digital prepaid products are in one place!\n

              Recharge a phone anywhere in the world. Or get a digital prepaid code for your favourite entertainment service, game or online shop. It’s as fast, safe and simple as always. Only, better.\n

              Welcome to the new TyP!`}
            </Typography.Text>
          </Row>
          <Row>
            <Typography.Title level={4}>Recharge credit worldwide in seconds</Typography.Title>
          </Row>
          <Row className={styles.mb10}>
            <Typography.Text className={styles.contentText}>
              {`Here at TyP, we believe in living on your own terms. Whether you want to buy call credit, enjoy your favourite tv shows and music, or play games, you should do it your way. That means from anywhere, at any time, using whatever payment method you prefer. You’re in charge.\n

              Digital prepaid credit lets you enjoy the things you like on your terms. And we’ve made it our mission to ensure that buying digital credit is fast, safe and simple`}
            </Typography.Text>
          </Row>
          <Row>
            <Typography.Title level={4}>The people behind TyP</Typography.Title>
          </Row>
          <Row className={styles.mb10}>
            <Typography.Text className={styles.contentText}>
              {`Since it all started in 2002, we’ve grown a lot. From a small group of enthusiasts that could fit in a single room, we’ve become a global team of 100+ people. You’ll find us in our offices in Amsterdam.\n

              We’re bound together by our passion to make people’s lives easier. That’s the one thing that’s never going to change, however fast we grow.`}
            </Typography.Text>
          </Row>
          <Row>
            <Typography.Title level={4}>Who we are: our contact details</Typography.Title>
          </Row>
          <Row className={styles.mb10}>
            <Typography.Text className={styles.contentText}>
              {`The TyP platform is a service of Top Up B.V. which forms part of Creative Group (CG Holding B.V.).\n

              The TyP platform for international mobile top-up is a service of Recharge B.V., which forms part of Creative Group.\n

              Our (contact) details:\n

              TyP, trade name of Creative Group\n

              Kerkenbos 13-01\n
              6546 BG Nijmegen\n
              Email: help@typ.com\n

              Top Up B.V. is registered at the Dutch Chamber of Commerce, under number: 09213436 VAT number: NL8217.53.290.\n

              Recharge B.V. is registered at the Dutch Chamber of Commerce, under number: 24369398 VAT number: 8138.82.308.B.01\n

              You can also contact our customer service team via the FAQ form on our website.\n

              TyP Holdings, INC en Rapido US, INC\n

              38 Yen Bai, Da Nang\n

              Da Nang, Viet Nam`}
            </Typography.Text>
          </Row>
        </Col>
      </Row>
    </div>
  )
};

export default AboutUs;
