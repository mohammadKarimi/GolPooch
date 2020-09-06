import React from 'react';
import Authorization from '../auth';
import { Route, Switch } from 'react-router-dom';

const EmptyLayout = () => {
    return (
        <Switch>
            <Route path="/" component={Authorization} />
        </Switch>
    );
}
export default EmptyLayout;