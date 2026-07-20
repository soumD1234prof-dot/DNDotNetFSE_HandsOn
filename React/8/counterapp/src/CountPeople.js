import React from 'react';
import './CountPeople.css';

class CountPeople extends React.Component {
    constructor() {
        super();
        this.state = {
            entrycount: 0,
            exitcount: 0,
            c: 0
        };
    }

    updateEntry() {
        this.setState((prevState, props) => {
            return { entrycount: prevState.entrycount + 1 }
        });
    }

    updateExit() {
        this.setState((prevState, props) => {
            return { exitcount: prevState.exitcount + 1 }
        });
    }

    render() {
        return (
            <div className="counter-container">
                <div className="counter-group">
                    <button className="counter-btn" onClick={() => this.updateEntry()}>Login</button>
                    <span> {this.state.entrycount} People Entered!!! </span>
                </div>

                <div className="counter-group">
                    <button className="counter-btn" onClick={() => this.updateExit()}>Exit</button>
                    <span> {this.state.exitcount} People Left!!! </span>
                </div>
            </div>
        );
    }
}

export default CountPeople;