package codecrusaders.business;

import codecrusaders.domain.*;

import java.util.Optional;

public interface ITestStepManager {
    CreateTestStepResponse registerTestStep(CreateTestStepRequest request);
    GetTestStepsResponse getTestSteps();
    GetTestStepsResponse getTestStepBySubTestId(Long subTestId);
    Optional<TestStep> getTestStepById(Long id);
}
