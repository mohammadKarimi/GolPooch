import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Authorization from './routes/auth';
import EmptyLayout from './routes/emptyLayout';

export default class App extends Component {
    render() {
        return (
            <Router className="layout">
                <Switch>
                    <Route path="/login" component={EmptyLayout} />
                </Switch>
            </Router>
        );
    }
}