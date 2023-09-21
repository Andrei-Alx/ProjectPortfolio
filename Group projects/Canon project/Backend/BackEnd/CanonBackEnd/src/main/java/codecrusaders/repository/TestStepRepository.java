package codecrusaders.repository;

import codecrusaders.controller.TestStepController;
import codecrusaders.repository.entity.ErrorEntity;
import codecrusaders.repository.entity.TestStepEntity;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface TestStepRepository extends JpaRepository<TestStepEntity, Long> {
    //    boolean existsById(long testStepId);
//    boolean stepExistByError(String errorMessage);
    List<TestStepEntity> findAll();

    List<TestStepEntity> findBySubTestID(Long subTestId);

    Optional<TestStepEntity> findById(Long id);
    @Query(value = "select * from teststeps where  errorid = :id",
            nativeQuery = true)
    List<TestStepEntity> getSimilarTestSteps(@Param("id") Long id);

    @Query("SELECT t FROM TestStepEntity t " +
            "JOIN SubTestEntity st ON t.subTestID = st.id " +
            "JOIN RegressionTestEntity rt ON st.testID = rt.id " +
            "JOIN TestSetEntity ts ON rt.testSetId = ts.id " +
            "JOIN TestBatchEntity tb ON ts.testBatchId = tb.id " +
            "JOIN BranchEntity b ON tb.branchId = b.id " +
            "WHERE b.isPublic = true AND t.errorID = ?1 " +
            "ORDER BY t.id DESC")
    List<TestStepEntity> findByErrorIdFromPublicBranchWithDescOrder(Long errorID);

    @Query("SELECT t FROM TestStepEntity t " +
            "JOIN SubTestEntity st ON t.subTestID = st.id " +
            "JOIN RegressionTestEntity rt ON st.testID = rt.id " +
            "JOIN TestSetEntity ts ON rt.testSetId = ts.id " +
            "JOIN TestBatchEntity tb ON ts.testBatchId = tb.id " +
            "JOIN BranchEntity b ON tb.branchId = b.id " +
            "WHERE b.isPublic = true AND t.errorID = ?1 " +
            "ORDER BY t.id DESC")
    Page<TestStepEntity> findByErrorIdFromPublicBranchWithDescOrder(Long errorID, Pageable pageable);

    @Query("SELECT COUNT(t) FROM TestStepEntity t " +
            "JOIN SubTestEntity st ON t.subTestID = st.id " +
            "JOIN RegressionTestEntity rt ON st.testID = rt.id " +
            "JOIN TestSetEntity ts ON rt.testSetId = ts.id " +
            "JOIN TestBatchEntity tb ON ts.testBatchId = tb.id " +
            "JOIN BranchEntity b ON tb.branchId = b.id " +
            "WHERE b.isPublic = true AND t.errorID = ?1 ")
    int countByErrorIdFromPublicBranch(Long errorID);

    @Query("SELECT t FROM TestStepEntity t " +
            "JOIN SubTestEntity st ON t.subTestID = st.id " +
            "JOIN RegressionTestEntity rt ON st.testID = rt.id " +
            "JOIN TestSetEntity ts ON rt.testSetId = ts.id " +
            "JOIN TestBatchEntity tb ON ts.testBatchId = tb.id " +
            "JOIN BranchEntity b ON tb.branchId = b.id " +
            "WHERE b.isPublic = false AND t.errorID = ?1 AND b.userid = ?2 " +
            "ORDER BY t.id DESC")
    Page<TestStepEntity> findByErrorIdFromPrivateBranchWithDescOrder(Long errorID, Long userid, Pageable pageable);

    @Query("SELECT COUNT(t) FROM TestStepEntity t " +
            "JOIN SubTestEntity st ON t.subTestID = st.id " +
            "JOIN RegressionTestEntity rt ON st.testID = rt.id " +
            "JOIN TestSetEntity ts ON rt.testSetId = ts.id " +
            "JOIN TestBatchEntity tb ON ts.testBatchId = tb.id " +
            "JOIN BranchEntity b ON tb.branchId = b.id " +
            "WHERE b.isPublic = false AND t.errorID = ?1AND b.userid = ?2 ")
    int countByErrorIdFromPrivateBranch(Long errorID, Long userid);
}
