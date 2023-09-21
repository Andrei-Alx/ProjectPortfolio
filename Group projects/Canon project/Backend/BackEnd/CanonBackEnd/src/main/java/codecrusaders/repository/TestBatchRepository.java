package codecrusaders.repository;

import codecrusaders.repository.entity.TestBatchEntity;
import codecrusaders.repository.entity.TestSetEntity;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface TestBatchRepository extends JpaRepository<TestBatchEntity, Long> {
    @Query(value = "SELECT * FROM testbatches WHERE branchid = :branchId", nativeQuery = true)
    List<TestBatchEntity> getAllTestBatchesByBranchEntityId(@Param("branchId")Long branchId);

    @Query(value = "SELECT tb FROM TestBatchEntity tb " +
            "JOIN BranchEntity br ON tb.branchId = br.id " +
            "WHERE tb.version = ?1 AND br.isPublic = true " +
            "ORDER BY tb.id DESC")
    Page<TestBatchEntity> getTestBatchesByVersionFromPublic(String version, Pageable pageable);

    @Query(value = "SELECT COUNT(tb) FROM TestBatchEntity tb " +
            "JOIN BranchEntity br ON tb.branchId = br.id " +
            "WHERE tb.version = ?1 AND br.isPublic = true ")
    int countTestBatchesByVersionFromPublic(String version);

    @Query(value = "SELECT tb FROM TestBatchEntity tb " +
            "JOIN BranchEntity br ON tb.branchId = br.id " +
            "WHERE tb.commitShal = ?1 AND br.isPublic = true " +
            "ORDER BY tb.id DESC")
    Page<TestBatchEntity> getTestBatchesByCommitFromPublic(String commitShal, Pageable pageable);

    @Query(value = "SELECT COUNT(tb) FROM TestBatchEntity tb " +
            "JOIN BranchEntity br ON tb.branchId = br.id " +
            "WHERE tb.commitShal = ?1 AND br.isPublic = true ")
    int countTestBatchesByCommitFromPublic(String commitShal);

    @Query(value = "SELECT tb FROM TestBatchEntity tb " +
            "JOIN BranchEntity br ON tb.branchId = br.id " +
            "WHERE tb.version = ?1 AND br.isPublic = false AND br.userid = ?2 " +
            "ORDER BY tb.id DESC")
    Page<TestBatchEntity> getTestBatchesByVersionFromPrivate(String version, Long userId, Pageable pageable);

    @Query(value = "SELECT COUNT(tb) FROM TestBatchEntity tb " +
            "JOIN BranchEntity br ON tb.branchId = br.id " +
            "WHERE tb.version = ?1 AND br.isPublic = false AND br.userid = ?2 ")
    int countTestBatchesByVersionFromPrivate(String version, Long userId);

    @Query(value = "SELECT tb FROM TestBatchEntity tb " +
            "JOIN BranchEntity br ON tb.branchId = br.id " +
            "WHERE tb.commitShal = ?1 AND br.isPublic = false AND br.userid = ?2 " +
            "ORDER BY tb.id DESC")
    Page<TestBatchEntity> getTestBatchesByCommitFromPrivate(String commitShal, Long userId, Pageable pageable);

    @Query(value = "SELECT COUNT(tb) FROM TestBatchEntity tb " +
            "JOIN BranchEntity br ON tb.branchId = br.id " +
            "WHERE tb.commitShal = ?1 AND br.isPublic = false AND br.userid = ?2 ")
    int countTestBatchesByCommitFromPrivate(String commitShal, Long userId);
}
