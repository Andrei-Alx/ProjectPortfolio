import React, { useState, useEffect } from "react"
import { useNavigate } from "react-router-dom";
import PostAPI from "../apis/postsApi";
import CardList from "../components/CardList/CardList";
import 'react-bootstrap';
import "./ProfilePage.css";

function MyPostsPage() {
    const [posts, setPosts] = useState(null);
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

    const getUserPosts = () => {
        PostAPI.getMyPosts()
            .then((response) => {
                setPosts(response.data.posts)
            })
            .catch()
    };

    useEffect(() => {
        checkLogin();
        getUserPosts();
    }, []);

    return (
        <div>
            <h1>Here you can find all posts that you added to The Grand Slam Chronicles</h1>
            <div className="profile-page-container">
                <CardList posts={posts} />
            </div>
        </div>
    );
}

export default MyPostsPage;