package codecrusaders.repository;

import codecrusaders.repository.entity.BranchEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface BranchRepository extends JpaRepository<BranchEntity, Long> {

    //UserEntity findByName (String branchName);

    @Query(value = "SELECT * FROM branches WHERE ispublic = 1", nativeQuery = true)
    List<BranchEntity> findAllPublic();

    @Query(value = "  Select * from branches where ispublic = 1 or userid = :userid ;", nativeQuery = true)
    List<BranchEntity> findAllPrivate(@Param("userid")Long userid);
}
