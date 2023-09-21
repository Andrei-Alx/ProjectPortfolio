package org.example.business.impl;

import org.example.domain.Post;
import org.example.persistance.entity.PostEntity;

public final class PostConvertor {
    public static Post convert(PostEntity postEntity) {
        return Post.builder()
                .id(postEntity.getId())
                .title(postEntity.getTitle())
                .videoLink(postEntity.getVideoLink())
                .imageLink(postEntity.getImageLink())
                .likes(postEntity.getLikes())
                .winnerPlayer(postEntity.getWinnerPlayer())
                .description(postEntity.getDescription())
                .userEmail(postEntity.getUserEmail())
                .isPostVisible(postEntity.getIsPostVisible())
                .build();
    }
}
