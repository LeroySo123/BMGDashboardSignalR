import React, { useState } from 'react';
import PropTypes from 'prop-types';

async function loginUser(credentials) {
    return fetch('https://localhost:7091/api/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(credentials)
    })
        .then(data => data.json())
}


export default function Login({ setToken }) {
    const [username, setUserName] = useState()
    const [password, setPassword] = useState();

    const handleSubmit = async e => {
        e.preventDefault();
        const token = await loginUser({
            username,
            password
        });
        if (token.token !== "Fales")
        setToken(token);
    }

    return (
        <div className="login-wrapper container" >
            <h1>Please Log In</h1>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <p>Username</p>
                    <input type="text" onChange={e => setUserName(e.target.value)} />
                </div>
                <div className="form-group">
                    <p>Password</p>
                    <input type="password" onChange={e => setPassword(e.target.value)} />
                </div>
                <div className="form-group">
                    <button type="submit" class="btn btn-primary">Submit</button>
                </div>
            </form>
        </div>
    )
}

Login.propTypes = {
    setToken: PropTypes.func.isRequired
};