import React, { Component } from 'react';

export class Dashboard extends Component {

    constructor(props) {
        super(props);
        this.state = { activitybtns: [], loading: true };
    }



    componentDidMount() {
        this.populateActivityBtnData();
    }

    static renderActivityBtn(activitybtns) {
        return (
                <div>
                {activitybtns.map(activitybtn =>
                    <button className="btn btn-primary" value={activitybtn.buttonID} key={activitybtn.buttonID}>{activitybtn.text}</button>
                    )}
               </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Dashboard.renderActivityBtn(this.state.activitybtns);

        return (
            <div>
            <h2>Dashboard</h2>
                {contents}
            </div>
        );
    }

    async populateActivityBtnData() {
        const response = await fetch('api/ActivityBtn');
        const data = await response.json();
        this.setState({ activitybtns: data, loading: false });
    }
}