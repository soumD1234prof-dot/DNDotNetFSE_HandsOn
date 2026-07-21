import React from 'react';
import './ComplaintRegister.css';

class ComplaintRegister extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            ename: '',
            complaint: '',
            NumberHolder: 0
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    handleSubmit(event) {
        const refNumber = Math.floor(Math.random() * 100);
        this.setState({ NumberHolder: refNumber }, () => {
            var msg = 'Thanks ' + this.state.ename + '\nYour Complaint was Submitted. \nTransaction ID is: ' + this.state.NumberHolder;
            alert(msg);
        });
        event.preventDefault();
    }

    render() {
        return (
            <div className='complaint-container'>
                <h2 style={{ color: 'red' }}>Register your complaints here!!!</h2>
                <form onSubmit={this.handleSubmit}>
                    <label>Name: </label>
                    <input
                        type="text"
                        name="ename"
                        value={this.state.ename}
                        onChange={this.handleChange}
                    />
                    <br /><br />
                    <label>Complaint: </label>
                    <textarea
                        name="complaint"
                        value={this.state.complaint}
                        onChange={this.handleChange}
                    />
                    <br /><br />
                    <button type="submit">Submit</button>
                </form>
            </div>
        );
    }
}

export default ComplaintRegister;