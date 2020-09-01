import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import EmptyLayout from './routes/layouts/emptyLayout';
 

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