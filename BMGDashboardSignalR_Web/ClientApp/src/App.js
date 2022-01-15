import React, { useState } from 'react';
/*import { Route } from 'react-router';*/
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import { Dashboard } from './components/Dashboard';
import Login from './components/Login';

import './custom.css'


function App() {
    const [token, setToken] = useState();

    if (!token) {
        return <Login setToken={setToken} />
    }

    return (
        <div className="wrapper">
            <h1>Application</h1>
            <BrowserRouter>
                <Switch>
                    <Route path="/dashboard">
                        <Dashboard />
                    </Route>
                </Switch>
            </BrowserRouter>
        </div>
    );
}

export default App;