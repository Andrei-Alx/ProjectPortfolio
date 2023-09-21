package codecrusaders.repository;

import codecrusaders.repository.entity.ErrorEntity;
import codecrusaders.repository.entity.UserEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
@Repository
public interface UserRepository extends JpaRepository<UserEntity, Long> {

//     UserEntity findByID(long id);
//     boolean ExistsByName(String userName);

     UserEntity findByUserName(String username);
     List<UserEntity> findAll();
}
