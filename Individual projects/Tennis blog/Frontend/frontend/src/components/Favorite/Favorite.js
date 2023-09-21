import React from "react";
import { Link } from "react-router-dom";
import "./Favorite.css";
import favoritesApi from "../../apis/favoritesApi"

function Favorite({ id, postTitle, image, favoriteId}) {

    const handleDelete = () => {
            favoritesApi.deleteFavorite(favoriteId)
    };

    return (
        <div className="cardfav">
            
            <div className="card-imagefav">
                <img src={image} alt="Couldn't load data" />
            </div>
            <div className="card-contentfav">
                <h3>{postTitle}</h3>
                <div className="card-actionsfav">
                    <Link className="details-buttonfav" to={`/posts/${id}`}>
                        View Details
                    </Link>
                </div>
            </div>
        </div>
    );
}

export default Favorite;
