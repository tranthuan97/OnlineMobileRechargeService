import * as React from 'react';
import { connect } from 'react-redux';
import { Container, Row } from 'reactstrap';
import { Menu, Dropdown } from 'antd';
import { DownOutlined } from '@ant-design/icons';

const data = [
  '1st menu item',
  '2nd menu item',
];

const Home = () => {
  const dropdownList = React.useMemo(() => {
    return (
      <Menu>
        {data.map((item, index) => <Menu.Item key={index}>{item}</Menu.Item>)}
      </Menu>
    );
  }, []);

  return (
    <Container>
      <Row style={{ height: 500, justifyContent: 'center', alignItems: 'center' }}>
        <Dropdown overlay={dropdownList} trigger={['click']}>
          <a className="ant-dropdown-link" onClick={e => e.preventDefault()}>
            Click me <DownOutlined translate />
          </a>
        </Dropdown>
      </Row>
    </Container>
  )
};

export default connect()(Home);
