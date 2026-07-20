import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import Home from './Home';
import TrainersList from './TrainerList';
import TrainerDetail from './TrainerDetails';
import trainersMock from './TrainersMock';

function App() {
    return (
        <BrowserRouter>
        <h1>
          My Academy Trainers App
        </h1>
            <nav>
                <Link to="/">Home</Link> | <Link to="/trainers">Show Trainers</Link>
            </nav>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/trainers" element={<TrainersList trainers={trainersMock} />} />
                <Route path="/trainers/:id" element={<TrainerDetail />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;