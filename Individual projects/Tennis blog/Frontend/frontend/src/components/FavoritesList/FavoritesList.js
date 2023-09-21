import React from "react";
import Favorite from "../Favorite/Favorite.js"
import { useMediaQuery } from "react-responsive";
import classNames from 'classnames';
import "./FavoritesList.css";

function FavoritesList(props) {
const isSmallScreen = useMediaQuery({ maxWidth: 1080 });

const gridClassNames = classNames({
    'grid' : true,
    'grid--small-screenfav' : isSmallScreen,
    'grid--large-screenfav' : !isSmallScreen,
});

return (
    <div className={gridClassNames}>
    {props.favorites && props.favorites.map((post) => (
        <Favorite className="postCardfav" key={post.id} image={post.imageLink} video={post.videoLink} postTitle={post.title}
        description={post.description} author={post.userEmail} id={post.id}/>
    ))}
    </div>
);}

export default FavoritesList;