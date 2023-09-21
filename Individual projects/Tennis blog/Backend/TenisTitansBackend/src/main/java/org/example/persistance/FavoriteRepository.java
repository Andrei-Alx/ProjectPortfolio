package org.example.persistance;

import org.example.persistance.entity.FavoriteEntity;
import org.example.persistance.entity.PostEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface FavoriteRepository extends JpaRepository<FavoriteEntity, Long>{
    FavoriteEntity findById(long favoriteId);

    @Query("SELECT f.postId FROM FavoriteEntity f INNER JOIN PostEntity p ON f.postId = p.id WHERE f.loggedUser.id = :userId AND p.isPostVisible = :visibility")
    List<PostEntity> findPostIdsByUserId(@Param("userId") long userId, @Param("visibility") String visible);
}
