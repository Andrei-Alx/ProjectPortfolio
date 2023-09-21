import React, { useState, useEffect } from "react"
import usersApi from "../../apis/usersApi"
import postsApi from "../../apis/postsApi"
import './Badge.css';

function Stats() {
    const [userCount, setUserCount] = useState(null);
    const [postCount, setPostCount] = useState(null);

    const getUserCount = () => {
        usersApi.getUserCount()
            .then((response) => setUserCount(response.data.userCount))
            .catch()
    };

    const getPostCount = () => {
        postsApi.getPostCount()
            .then((response) => setPostCount(response.data.postCount))
            .catch()
    };

    useEffect(() => {
        getUserCount();
        getPostCount();
    }, []);

    return (
        <div>
            <span className="badge">Total users: {userCount}</span>
            <span className="badge">Total posts: {postCount}</span>
        </div>
    );
}

export default Stats;