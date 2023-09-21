package codecrusaders.business.search;

import codecrusaders.business.ISearchManager;
import codecrusaders.business.impl.converters.*;
import codecrusaders.domain.*;
import codecrusaders.repository.*;
import codecrusaders.repository.entity.*;
import lombok.AllArgsConstructor;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
@AllArgsConstructor
public class SearchManager implements ISearchManager {

    private final ErrorMessageRepository errorRepository;
    private final TestStepRepository testStepRepository;
    private final SubTestRepository subTestRepository;
    private final RegrTestRepository regressionTestRepository;
    private final TestSetRepository testSetRepository;
    private final TestBatchRepository testBatchRepository;
    private final BranchRepository branchRepository;
    private static final Logger logger = LoggerFactory.getLogger(SearchManager.class);
    public List<SearchResult> getByErrorIdFromPublic(Long errorId, int pageSize, int pageNumber) {
        try{
            List<SearchResult> results = new ArrayList<>();

            Pageable pageable = PageRequest.of(pageNumber - 1, pageSize);
            Page<TestStepEntity> pageResult = testStepRepository.findByErrorIdFromPublicBranchWithDescOrder(errorId, pageable);

            System.out.println(pageResult);

            List<TestStep> testSteps = pageResult.getContent()
                    .stream()
                    .map(TestStepConverter::convert)
                    .toList();

            for (TestStep testStep : testSteps) {
                SearchResult searchResult = constructFromBranchToTestStep(testStep.getId());
                results.add(searchResult);
            }

            return results;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }

    public int countPagesForErrorIdFromPublic(Long errorId, int pageSize){
        try{
            int totalTestSteps = testStepRepository.countByErrorIdFromPublicBranch(errorId);
            System.out.println("Total Test Steps: " + totalTestSteps);
            int totalPages = totalTestSteps / pageSize;
            if (totalTestSteps % pageSize != 0) {
                totalPages++;
            }
            System.out.println(totalPages);
            return totalPages;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }
    public List<SearchResult> getByVersionFromPublic(String version, int pageSize, int pageNumber){
        try{
            List<SearchResult> results = new ArrayList<>();

            Pageable pageable = PageRequest.of(pageNumber - 1, pageSize);
            Page<TestBatchEntity> pageResult = testBatchRepository.getTestBatchesByVersionFromPublic(version, pageable);

            System.out.println(pageResult);

            List<TestBatch> testBatches = pageResult.getContent()
                    .stream()
                    .map(TestBatchConverter::convert)
                    .toList();

            for (TestBatch testBatch : testBatches) {
                SearchResult searchResult = constructFromBranchToTestBatch(testBatch.getId());
                results.add(searchResult);
            }

            return results;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }
    public int countPagesForVersionFromPublic(String version, int pageSize){
        try{
            int totalTestBatches = testBatchRepository.countTestBatchesByVersionFromPublic(version);
            System.out.println("Total Test Batches: " + totalTestBatches);
            int totalPages = totalTestBatches / pageSize;
            if (totalTestBatches % pageSize != 0) {
                totalPages++;
            }
            System.out.println(totalPages);
            return totalPages;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }
    public List<SearchResult> getByCommitFromPublic(String commit, int pageSize, int pageNumber){
        try{
            List<SearchResult> results = new ArrayList<>();

            Pageable pageable = PageRequest.of(pageNumber - 1, pageSize);
            Page<TestBatchEntity> pageResult = testBatchRepository.getTestBatchesByCommitFromPublic(commit, pageable);

            System.out.println(pageResult);

            List<TestBatch> testBatches = pageResult.getContent()
                    .stream()
                    .map(TestBatchConverter::convert)
                    .toList();

            for (TestBatch testBatch : testBatches) {
                SearchResult searchResult = constructFromBranchToTestBatch(testBatch.getId());
                results.add(searchResult);
            }

            return results;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }
    public int countPagesForCommitFromPublic(String commit, int pageSize){
        try{
            int totalTestBatches = testBatchRepository.countTestBatchesByCommitFromPublic(commit);
            System.out.println("Total Test Batches: " + totalTestBatches);
            int totalPages = totalTestBatches / pageSize;
            if (totalTestBatches % pageSize != 0) {
                totalPages++;
            }
            System.out.println(totalPages);
            return totalPages;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }

    public List<SearchResult> getByErrorIdFromPrivate(Long errorId, Long userId, int pageSize, int pageNumber){
        try{
            List<SearchResult> results = new ArrayList<>();
            Pageable pageable = PageRequest.of(pageNumber - 1, pageSize);
            Page<TestStepEntity> pageResult = testStepRepository.findByErrorIdFromPrivateBranchWithDescOrder(errorId, userId, pageable);
            System.out.println(pageResult);
            List<TestStep> testSteps = pageResult.getContent()
                    .stream()
                    .map(TestStepConverter::convert)
                    .toList();
            for (TestStep testStep : testSteps) {
                SearchResult searchResult = constructFromBranchToTestStep(testStep.getId());
                results.add(searchResult);
            }
            return results;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }

    public int countPagesForErrorIdFromPrivate(Long errorId, Long userId, int pageSize){
        try{
            int totalTestSteps = testStepRepository.countByErrorIdFromPrivateBranch(errorId, userId);
            System.out.println("Total Test Steps: " + totalTestSteps);
            int totalPages = totalTestSteps / pageSize;
            if (totalTestSteps % pageSize != 0) {
                totalPages++;
            }
            System.out.println(totalPages);
            return totalPages;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }

    public List<SearchResult> getByVersionFromPrivate(String version, Long userId, int pageSize, int pageNumber){
        try{
            List<SearchResult> results = new ArrayList<>();

            Pageable pageable = PageRequest.of(pageNumber - 1, pageSize);
            Page<TestBatchEntity> pageResult = testBatchRepository.getTestBatchesByVersionFromPrivate(version, userId, pageable);

            System.out.println(pageResult);

            List<TestBatch> testBatches = pageResult.getContent()
                    .stream()
                    .map(TestBatchConverter::convert)
                    .toList();

            for (TestBatch testBatch : testBatches) {
                SearchResult searchResult = constructFromBranchToTestBatch(testBatch.getId());
                results.add(searchResult);
            }

            return results;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }

    public List<SearchResult> getByCommitFromPrivate(String commit, Long userId, int pageSize, int pageNumber){
        try{
            List<SearchResult> results = new ArrayList<>();

            Pageable pageable = PageRequest.of(pageNumber - 1, pageSize);
            Page<TestBatchEntity> pageResult = testBatchRepository.getTestBatchesByCommitFromPrivate(commit, userId, pageable);

            System.out.println(pageResult);

            List<TestBatch> testBatches = pageResult.getContent()
                    .stream()
                    .map(TestBatchConverter::convert)
                    .toList();

            for (TestBatch testBatch : testBatches) {
                SearchResult searchResult = constructFromBranchToTestBatch(testBatch.getId());
                results.add(searchResult);
            }

            return results;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }

    public int countPagesGetByVersionFromPrivate(String version, Long userId, int pageSize){
        try{
            int totalTestBatches = testBatchRepository.countTestBatchesByVersionFromPrivate(version, userId);
            System.out.println("Total Test Batches: " + totalTestBatches);
            int totalPages = totalTestBatches / pageSize;
            if (totalTestBatches % pageSize != 0) {
                totalPages++;
            }
            System.out.println(totalPages);
            return totalPages;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }

    public int countPagesGetByCommitFromPrivate(String commit, Long userId, int pageSize){
        try{
            int totalTestBatches = testBatchRepository.countTestBatchesByCommitFromPrivate(commit, userId);
            System.out.println("Total Test Batches: " + totalTestBatches);
            int totalPages = totalTestBatches / pageSize;
            if (totalTestBatches % pageSize != 0) {
                totalPages++;
            }
            System.out.println(totalPages);
            return totalPages;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }

    private SearchResult constructFromBranchToTestStep(Long testStepId){
        try{
            //Set Up Variables:
            TestStep testStep;
            SubTest subTest;
            RegressionTest regressionTest;
            TestSet testSet;
            TestBatch testBatch;
            Branch branch;

            //Retrieve From Database:
            TestStepEntity testStepEntity = testStepRepository.findById(testStepId).get();
            if(testStepEntity == null){
                throw new RuntimeException("Test step has not been found!");
            }
            testStep = TestStepConverter.convert(testStepEntity);
            System.out.println(testStep);


            SubTestEntity subtestEntity = subTestRepository.findById(testStep.getSubTestId()).get();
            if(subtestEntity == null){
                throw new RuntimeException("Subtest has not been found!");
            }
            subTest = SubTestConverter.convert(subtestEntity);
            System.out.println(subTest);

            RegressionTestEntity regressionTestEntity = regressionTestRepository.findById(subTest.getTestId()).get();
            if(regressionTestEntity == null){
                throw new RuntimeException("Subtest has not been found!");
            }
            regressionTest = RegrTestConverter.convert(regressionTestEntity);
            System.out.println(regressionTest);

            TestSetEntity testSetEntity = testSetRepository.findById(regressionTest.getTestSetId()).get();
            if(testSetEntity == null){
                throw new RuntimeException("Test set has not been found!");
            }
            testSet = TestSetConverter.convert(testSetEntity);
            System.out.println(testSet);

            TestBatchEntity testBatchEntity = testBatchRepository.findById(testSet.getTestBatchId()).get();
            if(testBatchEntity == null){
                throw new RuntimeException("Test set has not been found!");
            }
            testBatch = TestBatchConverter.convert(testBatchEntity);
            System.out.println(testBatch);

            BranchEntity branchEntity = branchRepository.findById(testBatch.getBranchId()).get();
            if(branchEntity == null){
                throw new RuntimeException("Branch has not been found!");
            }
            branch = BranchConverter.convert(branchEntity);
            System.out.println(branch);

            //Construct SearchResult:
            SearchResult result = SearchResult.builder()
                    .branch(branch)
                    .testBatch(testBatch)
                    .testSet(testSet)
                    .regressionTest(regressionTest)
                    .subTest(subTest)
                    .testStep(testStep)
                    .build();

            return result;
        }
        catch(Exception ex){
            logger.error(ex.getMessage());
            throw ex;
        }
    }
    private SearchResult constructFromBranchToTestBatch(Long testBatchid){
        //Set up variables:
        TestBatch testBatch;
        Branch branch;

        //Retrieve From Database:
        TestBatchEntity testBatchEntity = testBatchRepository.findById(testBatchid).get();
        if(testBatchEntity == null){
            throw new RuntimeException("Test batch has not been found!");
        }
        testBatch = TestBatchConverter.convert(testBatchEntity);
        System.out.println(testBatch);

        BranchEntity branchEntity = branchRepository.findById(testBatch.getBranchId()).get();
        if(branchEntity == null){
            throw new RuntimeException("Branch has not been found!");
        }
        branch = BranchConverter.convert(branchEntity);
        System.out.println(branch);

        //Construct SearchResult:
        SearchResult result = SearchResult.builder()
                .branch(branch)
                .testBatch(testBatch)
                .testSet(null)
                .regressionTest(null)
                .subTest(null)
                .testStep(null)
                .build();

        return result;
    }
}
