package org.example.business.impl;

import org.example.domain.Favorite;
import org.example.domain.Post;
import org.example.persistance.entity.FavoriteEntity;
import org.example.persistance.entity.PostEntity;

public class FavoriteConvertor {
    public static Favorite convert(FavoriteEntity favoriteEntity) {
        return Favorite.builder()
                .id(favoriteEntity.getId())
                .user(UserConvertor.convert(favoriteEntity.getLoggedUser()))
                .post(PostConvertor.convert(favoriteEntity.getPostId()))
                .build();
    }
}
