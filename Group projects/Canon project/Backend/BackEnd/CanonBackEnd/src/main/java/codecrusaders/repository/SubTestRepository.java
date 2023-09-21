package codecrusaders.repository;

import codecrusaders.repository.entity.ErrorEntity;
import codecrusaders.repository.entity.SubTestEntity;
import codecrusaders.repository.entity.TestStepEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
@Repository
public interface SubTestRepository extends JpaRepository<SubTestEntity, Long> {
    boolean existsById(long subTestId);
    SubTestEntity save(SubTestEntity subTestEntity);
    List<SubTestEntity> findAll();

    List<SubTestEntity> findByTestID(Long testId);

    @Query(value = "SELECT COUNT(*) FROM teststeps ts" +
            "                   JOIN subtests st ON ts.subtestid = st.subtestid" +
            "                   WHERE st.subtestid = :subtestid AND ts.testresult = 0", nativeQuery = true)
    int countFailedTestStepsBySubTestID(@Param("subtestid") Long subTestId);

    @Query(value = "SELECT COUNT(*) FROM teststeps ts" +
            "                   JOIN subtests st ON ts.subtestid = st.subtestid" +
            "                   WHERE st.subtestid = :subtestid", nativeQuery = true)
    int countTotalTestStepsBySubTestID(@Param("subtestid") Long subTestId);


}
