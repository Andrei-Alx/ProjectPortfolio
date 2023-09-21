package codecrusaders.repository;

import codecrusaders.domain.TestSet;
import codecrusaders.repository.entity.ErrorEntity;
import codecrusaders.repository.entity.TestBatchEntity;
import codecrusaders.repository.entity.TestSetEntity;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;
@Repository
public interface TestSetRepository extends JpaRepository<TestSetEntity, Long> {
    boolean existsById(long id);

    TestSetEntity save(TestSetEntity testSet);

    void deleteById(long id);

    List<TestSetEntity> findAll();


    @Query(value = "SELECT COUNT(*) FROM teststeps ts" +
            "                   JOIN subtests st ON ts.subtestid = st.subtestid" +
            "                   JOIN tests t ON st.testid = t.testid" +
            "                   WHERE t.testid = :testId AND ts.testresult = 0", nativeQuery = true)
    int countFailedTestStepsByTestId(@Param("testId") Long testId);


    @Query(value = "SELECT COUNT(*) FROM teststeps ts" +
            "                   JOIN subtests st ON ts.subtestid = st.subtestid" +
            "                   JOIN tests t ON st.testid = t.testid" +
            "                   WHERE t.testid = :testId", nativeQuery = true)
    int countTotalTestStepsByTestId(@Param("testId") Long testId);



    @Query(value = "SELECT * FROM testsets WHERE testbatchid = :testbatchid", nativeQuery = true)
    List<TestSetEntity> getAllTestSetsByBatchId(@Param("testbatchid")Long testBatchId);

    @Query(
//            value = "SELECT * FROM testsets ORDER BY testsetid DESC LIMIT 6;",
            value = "SELECT TOP 6 * FROM testsets ORDER BY testsetid DESC",
            nativeQuery = true
    )
    List<TestSetEntity> findLatestTestSets();
}
