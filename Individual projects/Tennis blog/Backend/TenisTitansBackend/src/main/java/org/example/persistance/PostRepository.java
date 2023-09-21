package org.example.persistance;

import org.example.persistance.entity.PostEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface PostRepository extends JpaRepository<PostEntity, Long> {
    PostEntity findById(long postId);
    @Query("select count(p.id) as postCount from PostEntity p ")
    int getAllPostsCount();
    @Query("select count(p.id) as postCount from PostEntity p where p.userEmail = :email")
    int getPostsCountPerUser(String email);
    List<PostEntity> searchPostEntitiesByUserEmailContainingAndIsPostVisible(String userEmail, String visibility);
    List<PostEntity> searchPostEntitiesByWinnerPlayerContainingAndIsPostVisible(String winnerPlayerSearch, String visibility);
    List<PostEntity> getPostEntitiesByIsPostVisibleIsLike(String visibility);
    @Query("select p from PostEntity p where p.isPostVisible = :visibility and p.userEmail = :email")
    List<PostEntity> getVisiblePostsByUserEmail(String visibility, String email);
}
