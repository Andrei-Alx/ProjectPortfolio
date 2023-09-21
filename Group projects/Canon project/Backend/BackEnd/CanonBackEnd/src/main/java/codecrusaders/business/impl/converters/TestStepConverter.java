package codecrusaders.business.impl.converters;

import codecrusaders.business.IErrorMessageManager;
import codecrusaders.domain.TestStep;
import codecrusaders.repository.entity.TestStepEntity;
import lombok.NoArgsConstructor;

@NoArgsConstructor
public class TestStepConverter {

    private IErrorMessageManager iErrorMessageManager;



    public static TestStep convert(TestStepEntity testStepEntity) {
        return TestStep.builder()
                .id(testStepEntity.getId())
                .testStepName(testStepEntity.getTestStepName())
                .testResult(testStepEntity.isTestResult())
                .description(testStepEntity.getDescription())
                .errorid(testStepEntity.getErrorID())
                .subTestId(testStepEntity.getSubTestID())
                .build();
    }
}
