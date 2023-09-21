import axios from "axios";
import "../RequestInterceptor";

const FAVORITES_BASE_URL = "http://localhost:8090/favorites";

const FavoritesAPI = {
    getFavorites: () => axios.get(FAVORITES_BASE_URL),
    createFavorite: (favorite) => axios.post(FAVORITES_BASE_URL, favorite)
        .then(response => response.data.id),
    deleteFavorite: (favoriteId) => axios.delete(`http://localhost:8090/favorites/${favoriteId}`, favoriteId)
    
};

export default FavoritesAPI;