import React, { useEffect, useState} from "react"
import { useNavigate } from "react-router-dom";
import UserAPI from "../apis/usersApi";
import UserList from "../components/UserList/UserList";

function UserManagementPage(){
    const token = sessionStorage.getItem("token");
    const navigate = useNavigate();
    const [users, setUsers] = useState(null);

    const getUsers = () => {
        UserAPI.getPlayers()
            .then((response) => setUsers(response.data.users))
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
        getUsers();
    },[]);

    return (
        <div>
            <p>User Management</p>
            <UserList users={users}/>
        </div>
    )
}

export default UserManagementPage;