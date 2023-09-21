package org.example.business.impl;

import lombok.AllArgsConstructor;
import org.example.business.IFavoriteManager;
import org.example.business.exception.UnauthorizedAccessException;
import org.example.controller.domain.AccessToken;
import org.example.controller.domain.favorite.CreateFavoriteRequest;
import org.example.controller.domain.favorite.CreateFavoriteResponse;
import org.example.controller.domain.favorite.ReadAllFavoritesRequest;
import org.example.controller.domain.favorite.ReadAllFavoritesResponse;
import org.example.domain.Favorite;
import org.example.domain.Post;
import org.example.persistance.FavoriteRepository;
import org.example.persistance.PostRepository;
import org.example.persistance.UserRepository;
import org.example.persistance.entity.FavoriteEntity;
import org.example.persistance.entity.PostEntity;
import org.example.persistance.entity.UserEntity;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@AllArgsConstructor
public class FavoriteManager implements IFavoriteManager {
    private final FavoriteRepository favoriteRepository;
    private final UserRepository userRepository;
    private final PostRepository postRepository;
    private final AccessToken accessToken;

    @Override
    public CreateFavoriteResponse createFavorite(CreateFavoriteRequest request) {

        UserEntity user = userRepository.findByEmail(accessToken.getSubject());
        PostEntity post = postRepository.findById(request.getPostId());

        FavoriteEntity newFavorite = FavoriteEntity.builder()
                .loggedUser(user)
                .postId(post)
                .build();

        FavoriteEntity savedFavorite = saveNewFavorite(newFavorite);

        return CreateFavoriteResponse.builder()
                .id(savedFavorite.getId())
                .build();
    }

    private FavoriteEntity saveNewFavorite(FavoriteEntity favorite){
        return favoriteRepository.save(favorite);
    }

    @Override
    public ReadAllFavoritesResponse getFavorites() {
        List<Post> favorites = favoriteRepository.findPostIdsByUserId(accessToken.getUserId(), "Visible")
                .stream()
                .map(PostConvertor::convert)
                .toList();

        return ReadAllFavoritesResponse.builder()
                .favorites(favorites)
                .build();
    }

    @Override
    public void deleteFavorite(long favoriteId) {
        this.favoriteRepository.deleteById(favoriteId);
    }
}
