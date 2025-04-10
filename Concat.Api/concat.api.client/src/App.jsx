import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Login from "./Auth/Login";
import Register from "./Auth/Register";
import "./App.css";

function App() {
    return (
        <Router>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container">
                    <Link className="navbar-brand" to="/">
                        Weather App
                    </Link>
                    <div className="collapse navbar-collapse">
                        <ul className="navbar-nav ms-auto">
                            <li className="nav-item">
                                <Link className="nav-link" to="/login">
                                    Giriş Yap
                                </Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/register">
                                    Qeyd
                                </Link>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

            <div className="container mt-4">
                <Routes>
                    <Route path="/" element={<Login />} />  {"http://localhost:7056/api/login"}
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} /> {"http://localhost:7056/api/register"}
                    
                </Routes>
            </div>
        </Router>
    );
}

export default App;
