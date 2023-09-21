package codecrusaders.repository;

import codecrusaders.repository.entity.ErrorEntity;
import codecrusaders.repository.entity.TestStepEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;
@Repository
public interface ErrorMessageRepository extends JpaRepository<ErrorEntity, Long> {
    ErrorEntity save(ErrorEntity errorEntity);
    List<ErrorEntity> findAll();
    Optional<ErrorEntity> findById(long errorId);
}
