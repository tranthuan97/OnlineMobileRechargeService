import React from 'react';
import Footer from '../Footer';
import NavMenu from '../NavMenu';

import styles from './styles.module.css';
export default class Layout extends React.PureComponent {
    render() {
        return (
            <React.Fragment>
                <NavMenu />
                <div className={styles.container}>
                    {this.props.children}
                </div>
                <Footer />
            </React.Fragment>
        );
    }
}