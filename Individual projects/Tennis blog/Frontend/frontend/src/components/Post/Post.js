import React, { useState } from "react";
import { Link } from "react-router-dom";
import "./Post.css";
import favoritesApi from "../../apis/favoritesApi"
import PostAPI from "../../apis/postsApi";

function Post({ id, postTitle, image, visibility }) {
    const [isFavorite, setIsFavorite] = useState(false);
    const [isVisible, setIsVisible] = useState(visibility);
    const token = sessionStorage.getItem("token");

    const favorite = {
        postId: id
    }
    const request = {
        id:id,
        newVisibility:isVisible
    }

const handleVisibilityConfirm = () =>{
    PostAPI.updateVisibility(request)
        .then((response)=>{
        })
        .catch(function (error){
        })
}

    const handleToggleFavorite = () => {
        if (!isFavorite) {
            favoritesApi.createFavorite(favorite)
                .then((response) => {
                    setIsFavorite(true);
                    alert("Favorite added!");
                })
                .catch(function (error) {
                    setIsFavorite(false);
                    alert("Couldn't add favorite!")
                });
        } else {
            favoritesApi.deleteFavorite(id)
            setIsFavorite(false);
        }
    };
    if (token != null) {
        const parts = token.split('.');
        const payload = parts[1];
        const decodedPayload = atob(payload);
        const parsedPayload = JSON.parse(decodedPayload);
        const role = parsedPayload.roles[0];

        if (role === "Player") {
            return (
                <div className="card">

                    <div className="card-image">
                        <img src={image} alt="Couldn't load data" />
                    </div>
                    <div className="card-content">
                        <h3>{postTitle}</h3>
                        <div className="card-actions">
                            <button
                                className={`favorite-button ${isFavorite ? "favorite" : ""}`}
                                onClick={handleToggleFavorite}
                            >
                                {isFavorite ? "Remove from favorites" : "Add to favorites"}
                            </button>
                            <Link className="details-button" to={`/posts/${id}`}>
                                View Details
                            </Link>
                        </div>
                    </div>
                </div>
            );
        }
        else if (role === "Admin") {
            return (
                <div className="card">

                    <div className="card-image">
                        <img src={image} alt="Couldn't load data" />
                    </div>
                    <div className="card-content">
                        <h3>{postTitle}</h3>
                        <div className="card-actions">
                            <select id="isVisible" value={isVisible} onChange={(event) => setIsVisible(event.target.value)} className="combo-input">
                                <option value="Visible">Visible</option>
                                <option value="Invisible">Invisible</option>
                            </select>
                            <button className="details-button" onClick={handleVisibilityConfirm}>Confirm</button>
                            <Link className="details-button" to={`/posts/${id}`}>
                                View Details
                            </Link>
                        </div>
                    </div>
                </div>
            );
        }
    }
    else {
        return (
            <div className="card">

                <div className="card-image">
                    <img src={image} alt="Couldn't load data" />
                </div>
                <div className="card-content">
                    <h3>{postTitle}</h3>
                    <div className="card-actions">
                        <button
                            className={`favorite-button ${isFavorite ? "favorite" : ""}`}
                            onClick={handleToggleFavorite}
                        >
                            {isFavorite ? "Remove from favorites" : "Add to favorites"}
                        </button>
                        <Link className="details-button" to={`/posts/${id}`}>
                            View Details
                        </Link>
                    </div>
                </div>
            </div>
        );
    }
}

export default Post;
