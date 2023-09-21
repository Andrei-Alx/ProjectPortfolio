package org.example.persistance;

import org.example.persistance.entity.UserEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;
import java.util.Optional;

public interface UserRepository extends JpaRepository<UserEntity, Long> {
    UserEntity findById(long userId);

    UserEntity findByEmail(String email);

    Optional<UserEntity> findUserEntityByEmail(String email);

    List<UserEntity> findUserEntitiesByUserRoleIsLike(int role);

    @Query("select count(u.id) as userCount from UserEntity u ")
    int getAllUsersCount();
}
