import axios from "axios";
import "../RequestInterceptor";

const POSTS_BASE_URL = "http://localhost:8090/posts";

const PostAPI = {
    getPosts: () => axios.get(`http://localhost:8090/posts/adminposts`),
    getVisiblePosts: () => axios.get(POSTS_BASE_URL),
    getPostsByWinner: (winner) => axios.get(`http://localhost:8090/posts/search/${winner}`, winner),
    getPostsByAuthor: (author) => axios.get(`http://localhost:8090/posts/searchAuthor/${author}`, author),
    getPost: (id) => axios.get(`http://localhost:8090/posts/${id}`, id),
    getPostCount: () => axios.get("http://localhost:8090/posts/count"),
    getMyPosts: () => axios.get(`http://localhost:8090/posts/myposts`),
    getPostCountPerUser: (email) => axios.get(`http://localhost:8090/posts/userPostCount/${email}`, email),
    createPost: (post) => axios.post(POSTS_BASE_URL, post)
        .then(response => response.data.id),
    updatePost: (id, request) => axios.put(`http://localhost:8090/posts/${id}`, request),
    updateVisibility: (request) => axios.patch(POSTS_BASE_URL, request),
    deletePost: (id) => axios.delete(`http://localhost:8090/posts/${id}`, id)
};

export default PostAPI;