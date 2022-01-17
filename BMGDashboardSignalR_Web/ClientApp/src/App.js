import React, { useState } from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import { Dashboard } from './components/Dashboard';
import Login from './components/Login';
import { Counter } from './components/Counter';

import './custom.css'


function App() {
    const [token, setToken] = useState();

    if (!token) {
        return <Login setToken={setToken} />
    }

    return (
        <div className="wrapper">
            <BrowserRouter>
                <Switch>
                    <Route path="/">
                        <Dashboard dataFromParent={token.token} />
                    </Route>
                </Switch>
            </BrowserRouter>
        </div>
    );
}

export default App;