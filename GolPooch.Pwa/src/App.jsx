import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import EmptyLayout from './layouts/emptyLayout';
import NavigationLayout from './layouts/navigationLayout';

export default class App extends Component {
    render() {
        return (
            <Router className="layout">
                <Switch>
                    <Route path="/login" component={EmptyLayout} />
                    <Route path="/" component={NavigationLayout} />
                </Switch>
            </Router>
        );
    }
}