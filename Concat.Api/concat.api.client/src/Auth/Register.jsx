import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";

const Register = () => {
    const [formData, setFormData] = useState({ Name: "", Password: "", Lastname: "" });
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        axios.post('https://localhost:7056/api/Register', { Name: 'name', Lastname: 'Flintstone', Password:"3ee43ws23e" }).then(function (response) { console.log(response); }).catch(function (error) { console.log(error); });
    };

    return (
        <div className="container d-flex align-items-center justify-content-center vh-100">
            <div className="card p-4 shadow-lg" style={{ maxWidth: "400px", width: "100%" }}>
                <h3 className="text-center">Hesab Yarat</h3>
                {error && <div className="alert alert-danger">{error}</div>}
                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <label className="form-label">Ad</label>
                        <input
                            type="text"
                            name="Name"
                            className="form-control"
                            onChange={handleChange}
                            required
                        />
                    </div>

                    <div className="mb-3">
                        <label className="form-label">Soyad</label>
                        <input
                            type="text"
                            name="Lastname"
                            className="form-control"
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">Parol</label>
                        <input
                            type="password"
                            name="Password"
                            className="form-control"
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-success w-100">
                        Kayıt Ol
                    </button>
                </form>
                <div className="mt-3 text-center">
                    <p>
                        Hesabin var? <Link to="/login">Giriş</Link>
                    </p>
                </div>
            </div>
        </div>
    );
};

export default Register;
