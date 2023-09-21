import React, { useState } from "react";
import "./LogInForm.css";
import { useNavigate } from "react-router-dom";
import UserAPI from "../../apis/usersApi";
import LoginAPI from "../../apis/loginApi";

function LoginForm() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();

    const addUser = (user) => {
        UserAPI.createUser(user)
            .catch(function (error) {
            });
    };

    const handleLogin = (event) => {
        event.preventDefault();
        const credentials = {
            email: email,
            password: password
        }
        LoginAPI.login(credentials)
            .then((response) => {
                sessionStorage.setItem("token", response.data.accessToken)
                navigate("/");
                window.location.reload();
            })
            .catch(function (error) {
                sessionStorage.removeItem("token")
                alert("Login failed! Check your email and password!")
            });
    };

    const handleSignUp = (event) => {
        event.preventDefault();
        setEmail(email);
        setPassword(password);
            const user = {
                email: email,
                role: 1,
                password: password
            }
        addUser(user);
        alert("User created!");
    };

    return (
        <form className="login-form">
            <h1 className="login-form__title">Login</h1>
            <label htmlFor="email" className="login-form__label">Email:</label>
            <input
                type="email"
                id="email"
                value={email}
                onChange={(event) => setEmail(event.target.value)}
                className="login-form__input"
            />
            <label htmlFor="password" className="login-form__label">Password:</label>
            <input
                type="password"
                id="password"
                value={password}
                onChange={(event) => setPassword(event.target.value)}
                className="login-form__input"
            />
            <button onClick={handleLogin} className="login-form__button">Log In</button>
            <button onClick={handleSignUp} className="login-form__button">Sign Up</button>
        </form>
    );
}

export default LoginForm;