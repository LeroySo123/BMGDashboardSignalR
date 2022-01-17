import React, { Component } from 'react';

function clickActivitybtn(data) {
    return fetch('https://localhost:7091/api/ActivityBtn/ClickActivityBtn', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
        .then(data => data.json())
        .catch((error) => {
            console.error('Error:', error);
        });
}


export class Dashboard extends Component {

    constructor(props) {
        super(props);
        this.state = { activitybtns: [], loading: true, usertoken: ""  };
    }

    incrementCounter(e) {
        clickActivitybtn(e);
    }

    componentDidMount() {
        this.populateActivityBtnData(this.props.dataFromParent);
    }

    renderActivityBtn(state) {
        return (
                <div>
                {state.activitybtns.map(activitybtn =>
                    <button className="btn btn-primary" onClick={e => this.incrementCounter(activitybtn.buttonID + ';' + state.usertoken)} value={activitybtn.buttonID} key={activitybtn.buttonID} >{activitybtn.text}</button>
                    )}
               </div>
        );
    }


    render() {
        const token = this.props.dataFromParent
        const userName = token.split(';')

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : this.renderActivityBtn(this.state);

        return (
            <div>
                <h1>Dashboard</h1>
                <h3>Walcome <b>{userName[1]}</b></h3>
                {contents}
            </div>
        );
    }

    async populateActivityBtnData(token) {
        const response = await fetch('https://localhost:7091/api/ActivityBtn');
        const data = await response.json();
        this.setState({ activitybtns: data, loading: false, usertoken: token });
    }
}