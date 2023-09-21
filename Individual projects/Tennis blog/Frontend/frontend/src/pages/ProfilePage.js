import React, { useState, useEffect } from "react"
import { useNavigate } from "react-router-dom";
import AddPostForm from "../components/AddPostForm/AddPostForm";
import LogOutButton from "../components/LogOutButton/LogOutButton";
import FavoritesAPI from "../apis/favoritesApi";
import FavoritesList from "../components/FavoritesList/FavoritesList";
import 'react-bootstrap';
import "./ProfilePage.css";

function ProfilePage(props) {
    const [favorites, setFavorites] = useState(null);
    const token = sessionStorage.getItem("token");
    const navigate = useNavigate();

    const checkLogin = () => {
        if (token === null) {
            navigate("/login");
        }
        else {
            const parts = token.split('.');
            const payload = parts[1];
            const decodedPayload = atob(payload);
            const parsedPayload = JSON.parse(decodedPayload);
            const role = parsedPayload.roles[0];

            if (role === "Admin") {
                navigate("/unauthorized")
            }
        }
    }

    const getFavorites = () => {
        FavoritesAPI.getFavorites()
            .then((response) => {
                setFavorites(response.data.favorites)
            })
            .catch()
    };

    useEffect(() => {
        checkLogin();
        getFavorites();
    }, []);

    return (
        <div>
            <h1>Welcome to your Grand Slam Chronicles profile!</h1>
            <div className="profile-page-container">
                <LogOutButton />
                <div className="add-post-form-container">
                    <AddPostForm xeventx={props} />
                </div>
                <div className="favorites-list-container">
                    <h3>Your favorite posts</h3>
                    <FavoritesList favorites={favorites} />
                </div>
            </div>
        </div>
    );
}

export default ProfilePage;