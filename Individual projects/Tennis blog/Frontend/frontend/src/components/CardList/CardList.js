import React from "react";
import Post from "../Post/Post";
import { useMediaQuery } from "react-responsive";
import classNames from 'classnames';
import "./CardList.css";

function CardList(props) {
const isSmallScreen = useMediaQuery({ maxWidth: 1080 });

const gridClassNames = classNames({
    'grid' : true,
    'grid--small-screen' : isSmallScreen,
    'grid--large-screen' : !isSmallScreen,
});

return (
    <div className={gridClassNames}>
    {props.posts && props.posts.map((post) => (
        <Post className="postCard" key={post.id} image={post.imageLink} video={post.videoLink} postTitle={post.title}
        description={post.description} author={post.userEmail} visibility={post.isPostVisible} id={post.id}/>
    ))}
    </div>
);}

export default CardList;