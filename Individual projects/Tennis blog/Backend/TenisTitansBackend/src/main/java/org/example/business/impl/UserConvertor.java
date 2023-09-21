package org.example.business.impl;

import org.example.domain.User;
import org.example.persistance.entity.UserEntity;

public final class UserConvertor {
    public static User convert(UserEntity userEntity){
        return User.builder()
                .id(userEntity.getId())
                .email(userEntity.getEmail())
                .role(userEntity.getUserRole())
                .password(userEntity.getPassword())
                .isActive(userEntity.getIsUserActive())
                .build();
    }
}
