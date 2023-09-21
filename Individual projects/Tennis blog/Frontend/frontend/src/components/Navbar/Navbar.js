import React from "react"
import "./Navbar.css"
import { NavLink } from "react-router-dom"

function NavBar() {
    const token = sessionStorage.getItem("token");
    const notLoggedInLinks = [
        {
            id: 1,
            path: "/",
            text: "Home"
        },
        {
            id: 2,
            path: "/highlights",
            text: "Posts"
        },
        {
            id: 4,
            path: "/notifications",
            text: "Notifications"
        },
        {
            id: 5,
            path: "/login",
            text: "Log in"
        }
    ]
    const adminLinks = [
        {
            id: 1,
            path: "/",
            text: "Home"
        },
        {
            id: 2,
            path: "/admin",
            text: "Manage posts"
        },
        {
            id: 3,
            path: "/userManagement",
            text: "Manage users"
        },
    ]
    const playerLinks = [
        {
            id: 1,
            path: "/",
            text: "Home"
        },
        {
            id: 2,
            path: "/highlights",
            text: "Posts"
        },
        {
            id: 3,
            path: "/myposts",
            text: "My posts"
        },
        {
            id: 4,
            path: "/profile",
            text: "Profile"
        },
        {
            id: 5,
            path: "/notifications",
            text: "Notifications"
        }
    ]

    if(token === null)
    {
        return (
            <nav className="navbar">
                <ul className="navbar-ul">
                    {notLoggedInLinks.map(link => {
                        return (
                            <li key={link.id}>
                                { <NavLink className="navbar-ul-li-a" to={link.path}> {link.text} </NavLink> }
                            </li>
                        )
                    })}
                </ul>
            </nav>
        )
    }
    else
    {
        const parts = token.split('.');
        const payload = parts[1];
        const decodedPayload = atob(payload);
        const parsedPayload = JSON.parse(decodedPayload);
        const role = parsedPayload.roles[0];

        if(role === "Player")
        {
            return (
                <nav className="navbar">
                    <ul className="navbar-ul">
                        {playerLinks.map(link => {
                            return (
                                <li key={link.id}>
                                    { <NavLink className="navbar-ul-li-a" to={link.path}> {link.text} </NavLink> }
                                </li>
                            )
                        })}
                    </ul>
                </nav>
            )
        }
        else if(role === "Admin")
        {
            return (
                <nav className="navbar">
                    <ul className="navbar-ul">
                        {adminLinks.map(link => {
                            return (
                                <li key={link.id}>
                                    { <NavLink className="navbar-ul-li-a" to={link.path}> {link.text} </NavLink> }
                                </li>
                            )
                        })}
                    </ul>
                </nav>
            )
        }
    }
}

export default NavBar;