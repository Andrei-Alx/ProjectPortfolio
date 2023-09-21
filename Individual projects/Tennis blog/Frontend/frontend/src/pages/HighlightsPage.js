import React, { useState, useEffect } from "react"
import CardList from "../components/CardList/CardList";
import PostAPI from "../apis/postsApi";
import Search from "../components/Search/Search";

function HighlightsPage(){
    const [posts, setPosts] = useState(null);

    const getPosts = () => {
        PostAPI.getVisiblePosts()
            .then((response) => setPosts(response.data.posts))
            .catch()
    };

    useEffect(() => {
        getPosts();
    }, []);

return (<div>
            <p>Highlights Page</p>
            <Search/>
        </div>
    )
}

export default HighlightsPage;