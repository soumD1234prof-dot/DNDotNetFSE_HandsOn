import './App.css';
import { useState } from 'react';

// Reusable Button Components
function LoginButton(props) {
  return (
    <button onClick={props.onClick}>
      Login
    </button>
  );
}

function LogoutButton(props) {
  return (
    <button onClick={props.onClick}>
      Logout
    </button>
  );
}

// Greeting Components
function UserGreeting() {
  return <h2>Welcome back!!!</h2>;
}

function GuestGreeting() {
  return <h2>Please sign up!</h2>;
}

function Greeting(props) {
  const isLoggedIn = props.isLoggedIn;
  if (isLoggedIn) {
    return <UserGreeting />;
  }
  return <GuestGreeting />;
}

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLogin = () => {
    setIsLoggedIn(true);
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
  };

  return (
    <div className="App">
      <h1>Ticket Booking App</h1>

      <Greeting isLoggedIn={isLoggedIn} />

      <div className="button-container">
        {isLoggedIn ? (
          <LogoutButton onClick={handleLogout} />
        ) : (
          <LoginButton onClick={handleLogin} />
        )}
      </div>

      {/* Flight Details - Visible to Everyone */}
      <div className="flights">
        <h2>Available Flights</h2>
        <div className="flight-card">
          <h3>Delhi → Mumbai</h3>
          <p><strong>Price:</strong> ₹4,500</p>
          <p><strong>Time:</strong> 07:30 AM</p>
          {isLoggedIn && <button className="book-btn">Book Ticket</button>}
        </div>

        <div className="flight-card">
          <h3>Bangalore → Chennai</h3>
          <p><strong>Price:</strong> ₹3,200</p>
          <p><strong>Time:</strong> 09:15 AM</p>
          {isLoggedIn && <button className="book-btn">Book Ticket</button>}
        </div>
      </div>

      {isLoggedIn && (
        <div className="message">
          <p><strong>You can now book tickets!</strong></p>
        </div>
      )}
    </div>
  );
}

export default App;