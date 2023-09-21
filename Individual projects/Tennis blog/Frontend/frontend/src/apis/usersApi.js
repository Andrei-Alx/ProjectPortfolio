import axios from "axios";
import "../RequestInterceptor";

const USERS_BASE_URL = "http://localhost:8090/users";

const UserAPI = {
    getUsers: () => axios.get(USERS_BASE_URL),
    getPlayers: () => axios.get("http://localhost:8090/users/players"),
    getUserCount: () => axios.get("http://localhost:8090/users/count"),
    createUser: (user) => axios.post(USERS_BASE_URL, user)
        .then(response => response.data.id),
    deleteUser: (id) => axios.delete(`http://localhost:8090/users/${id}`, id),
    updateAccountStatus: (request) => axios.patch(USERS_BASE_URL, request),
};

export default UserAPI;