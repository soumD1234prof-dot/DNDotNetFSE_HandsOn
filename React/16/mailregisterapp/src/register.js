import React, { Component } from 'react';

// Helper function to check if the errors object is completely clean
const validateForm = (errors) => {
  let valid = true;
  Object.values(errors).forEach(
    (val) => val.length > 0 && (valid = false)
  );
  return valid;
};

class Register extends Component {
  constructor(props) {
    super(props);
    this.state = {
      fullName: '',
      email: '',
      password: '',
      errors: {
        fullName: '',
        email: '',
        password: ''
      }
    };
  }

  // Handle real-time input change & update state/errors
  handleChange = (event) => {
    event.preventDefault();
    const { name, value } = event.target;
    let errors = { ...this.state.errors };

    switch (name) {
      case 'fullName':
        errors.fullName =
          value.length < 5
            ? 'Full Name must be 5 characters long!'
            : '';
        break;

      case 'email':
        const validEmailRegex = RegExp(
          /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/i
        );
        errors.email = validEmailRegex.test(value)
          ? ''
          : 'Email is not valid!';
        break;

      case 'password':
        errors.password =
          value.length < 8
            ? 'Password must be 8 characters long!'
            : '';
        break;

      default:
        break;
    }

    this.setState({ errors, [name]: value });
  };

  // Handle form submission and display validation alerts
  handleSubmit = (event) => {
    event.preventDefault();

    if (validateForm(this.state.errors)) {
      alert('Valid Form');
    } else {
      if (this.state.errors.fullName !== '') {
        alert(this.state.errors.fullName);
      }
      if (this.state.errors.email !== '') {
        alert(this.state.errors.email);
      }
      if (this.state.errors.password !== '') {
        alert(this.state.errors.password);
      }
    }
  };

  render() {
    return (
      <div style={{ textAlign: 'center', marginTop: '50px' }}>
        <h1 style={{ color: 'red' }}>Register Here!!!</h1>
        
        <form onSubmit={this.handleSubmit} noValidate>
          <div style={{ marginBottom: '10px' }}>
            <label>Name: </label>
            <input
              type="text"
              name="fullName"
              onChange={this.handleChange}
            />
          </div>

          <div style={{ marginBottom: '10px' }}>
            <label>Email: </label>
            <input
              type="text"
              name="email"
              onChange={this.handleChange}
            />
          </div>

          <div style={{ marginBottom: '10px' }}>
            <label>Password: </label>
            <input
              type="password"
              name="password"
              onChange={this.handleChange}
            />
          </div>

          <div>
            <button type="submit">Submit</button>
          </div>
        </form>
      </div>
    );
  }
}

export default Register;