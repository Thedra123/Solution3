import React, { useEffect, useState } from "react";
import { Container, Button, Card } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

const MainScreen = () => {
    const [hospitals, setHospitals] = useState([]);

    useEffect(() => {
        fetch("http://localhost:5000/api/HospitalNo") // API endpoint
            .then((response) => response.json())
            .then((data) => setHospitals(data))
            .catch((error) => console.error("Error fetching hospitals:", error));
    }, []);

    return (
        <Container className="mt-3">
            <Card className="text-center bg-primary text-white p-3 mb-3">
                <h2>Welcome To Online Ticket App</h2>
            </Card>
            {hospitals.map((hospital) => (
                <Button
                    key={hospital.hospitalNo}
                    variant="secondary"
                    className="d-block w-100 p-3 mb-2"
                >
                    {hospital.hospitalName}, {hospital.hospitalNo} ({"Hospital Work Hours"})
                </Button>
            ))}
        </Container>
    );
};

export default MainScreen;
