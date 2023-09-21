package codecrusaders.business;

import codecrusaders.domain.*;
import codecrusaders.repository.entity.RegressionTestEntity;

import java.util.Optional;

public interface IRegressionTestManager {
    CreateRegrTestResponse createRegressionTest(CreateRegrTestRequest request);
    GetRegressionTestResponse getAllRegrTests();

    Optional<RegressionTest> getTestByID(long id);
    GetLatestTestsResponse getLatestTests(GetTestsByTestSetIdRequest request);


}
