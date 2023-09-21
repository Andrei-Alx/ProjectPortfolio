import axios from "axios";
import "../RequestInterceptor";

const API_BASE_URL = "http://localhost:8090";
const LOGIN_BASE_URL = API_BASE_URL+ "/login";

const LoginAPI = {
    login: (credentials) => axios.post(LOGIN_BASE_URL, credentials)
};

export default LoginAPI;