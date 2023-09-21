import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import PostAPI from "../apis/postsApi";
import PostDetails from "../components/PostDetails/PostDetails";

function PostDetailsPage() {
    const { id } = useParams();
    const [post, setPost] = useState(null);

    const getPost = () => {
        PostAPI.getPost(id)
            .then((response) => setPost(response.data))
            .catch()
    };

    useEffect(() => {
        getPost();
    }, []);

    if (!post) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <p>Post details</p>
            <PostDetails post={post}/>
        </div>
    );
}

export default PostDetailsPage;