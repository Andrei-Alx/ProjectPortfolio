package codecrusaders.business;

import codecrusaders.domain.*;

import java.util.Optional;

public interface ISubTestManager {
    CreateSubTestResponse registerSubTest(CreateSubTestRequest request);
    GetSubTestsResponse getSubTests();
    Optional<SubTest> findById(long subtestid);

    CountFailedTestStepResponse countFailedTestStep(CountFailedTestStepRequest request);
    CountFailedTestStepResponse countTotalTestStep(CountFailedTestStepRequest request);
    GetSubTestsResponse getSubTestsByTestID(Long id);

}
