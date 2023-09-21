import React from "react";
import "./LogOutButton.css";
import { useNavigate } from "react-router-dom";

function LogOutButton() {
    const navigate = useNavigate();

    const LogOut = () => {
        sessionStorage.removeItem("token");
        navigate("/");
        window.location.reload();
        
    };

    return (
        <button className="logout-button" onClick={LogOut}>
            Log Out
        </button>
    );
}

export default LogOutButton;
