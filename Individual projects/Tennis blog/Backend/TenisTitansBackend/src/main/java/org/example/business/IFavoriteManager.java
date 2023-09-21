package org.example.business;

import org.example.controller.domain.favorite.*;
import org.example.domain.Favorite;

public interface IFavoriteManager {
    CreateFavoriteResponse createFavorite(CreateFavoriteRequest request);
    ReadAllFavoritesResponse getFavorites();
    void deleteFavorite(long favoriteId);
}
