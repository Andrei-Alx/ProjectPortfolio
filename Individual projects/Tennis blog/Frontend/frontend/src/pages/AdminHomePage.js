import React, { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom";
import PostAPI from "../apis/postsApi";
import LogOutButton from "../components/LogOutButton/LogOutButton";
import CardList from "../components/CardList/CardList";
import Stats from "../components/Statistics/Stats";

function AdminHomePage(){
    const token = sessionStorage.getItem("token");
    const navigate = useNavigate();
    const [posts, setPosts] = useState(null);

    const getPosts = () => {
        PostAPI.getPosts()
            .then((response) => setPosts(response.data.posts))
            .catch()
    };

const checkLogin = () =>{
    if(token === null){
        navigate("/login");
    }
    else{
        const parts = token.split('.');
        const payload = parts[1];
        const decodedPayload = atob(payload);
        const parsedPayload = JSON.parse(decodedPayload);
        const role = parsedPayload.roles[0];

        if(role === "Player"){
            navigate("/unauthorized")
        }
    }
}

    useEffect(() => {
        checkLogin();
        getPosts();
    },[]);

    return (
        <div>
            <p>Admin Page</p>
            <LogOutButton/>
            <Stats/>
            <CardList posts={posts}/>
        </div>
    )
}

export default AdminHomePage;