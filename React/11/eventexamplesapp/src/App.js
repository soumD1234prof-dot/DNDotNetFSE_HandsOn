import './App.css';
import { useState } from 'react';

function App() {
  const [count, setCount] = useState(0);

  // 1. Increment - invokes multiple methods
  const increment = () => {
    setCount(prev => prev + 1);
    sayHello();
  };

  const sayHello = () => {
    alert("Hello! Member1");
  };

  // 2. Say Welcome button
  const sayWelcome = (greeting) => {
    alert(`${greeting}`);
  };

  // 3. Synthetic Event - Click handler
  const handleClick = (e) => {
    alert("I was clicked!!!");
  };

  // 4. Currency Converter
  const [amount, setAmount] = useState('');
  const [currency, setCurrency] = useState('Euro');
  const [result, setResult] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!amount) {
      alert("Please enter an amount");
      return;
    }

    // Approx conversion: 1 EUR ≈ 90 INR
    const euroAmount = (parseFloat(amount) / 90).toFixed(2);

    setCurrency('Euro');          
    setResult(`Converting to Euro Amount is ${euroAmount}`);
    
    alert(`Converting to Euro Amount is ${euroAmount}`);
  };

  return (
    <div className="App">
      <h1>Event Examples App</h1>

      {/* Counter Section */}
      <div className="section">
        <h2>Counter: {count}</h2>
        <button onClick={increment}>Increment</button>
        <button onClick={() => setCount(prev => prev - 1)}>Decrement</button>
        <button onClick={() => sayWelcome("welcome")}>Say welcome</button>
        <button onClick={handleClick}>Click on me</button>
      </div>

      {/* Currency Converter */}
      <div className="section">
        <h2>Currency Convertor!!!</h2>
        <form onSubmit={handleSubmit}>
          <div>
            <label>Amount: </label>
            <input 
              type="number" 
              value={amount}
              onChange={(e) => setAmount(e.target.value)}
              placeholder="Enter amount in INR"
            />
          </div>
          <div>
            <label>Currency: </label>
            <input 
              type="text" 
              value={currency}
              readOnly                  // Non-editable
            />
          </div>
          <button type="submit">Submit</button>
        </form>

        {result && <p style={{ marginTop: '20px', fontWeight: 'bold' }}>{result}</p>}
      </div>
    </div>
  );
}

export default App;