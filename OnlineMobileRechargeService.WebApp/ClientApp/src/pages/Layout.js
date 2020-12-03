import React from 'react';
import Footer from './Footer';
import NavMenu from './NavMenu';

export default class Layout extends React.PureComponent {
    render() {
        return (
            <React.Fragment>
                <NavMenu />
                {this.props.children}
                <Footer />
            </React.Fragment>
        );
    }
}