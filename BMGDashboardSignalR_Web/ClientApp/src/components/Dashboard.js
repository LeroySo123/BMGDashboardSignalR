import React, { Component } from 'react';
import { HubConnection } from 'signalr-client-react';

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
        this.state = { activitybtns: [], loading: true, usertoken: "", bookingMessage: "", Connection: null  };
    }

    incrementCounter(e) {
        clickActivitybtn(e);
    }

    componentDidMount = () => {
        this.populateActivityBtnData(this.props.dataFromParent);

        const bookingHubConnection = new HubConnection('https://localhost:7091/messagehub')

        this.setState({ Connection: bookingHubConnection }, () => {
            this.state.Connection.start()
                .then(() => console.log('SignalR Started'))
                .catch(err => console.log('Error connecting SignalR - ' + err));

            this.state.Connection.on('DashboardActivity', (message) => {
                const bookingMessage = message;
                this.setState({ bookingMessage: message });
            });
        });
    }

    renderActivityBtn(state) {
        return (
            <div className="container">
                <div className="row">
                    {state.activitybtns.map(activitybtn =>
                        <div className="col-lg-2">
                    <button className="btn btn-primary" onClick={e => this.incrementCounter(activitybtn.buttonID + ';' + state.usertoken)} value={activitybtn.buttonID} key={activitybtn.buttonID} >{activitybtn.text}</button>
                    </div>
                    )}
                </div>
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

                {this.state.bookingMessage}
            </div>
        );
    }

    async populateActivityBtnData(token) {
        const response = await fetch('https://localhost:7091/api/ActivityBtn');
        const data = await response.json();
        this.setState({ activitybtns: data, loading: false, usertoken: token });
    }
}