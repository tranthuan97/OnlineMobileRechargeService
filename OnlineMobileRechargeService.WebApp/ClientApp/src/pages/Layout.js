import * as React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';

export default class Layout extends React.PureComponent {
    render() {
        return (
            <React.Fragment>
                <NavMenu />
                {this.props.children}
            </React.Fragment>
        );
    }
}