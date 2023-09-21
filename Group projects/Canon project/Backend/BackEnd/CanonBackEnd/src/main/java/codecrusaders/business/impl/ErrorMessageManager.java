package codecrusaders.business.impl;

import codecrusaders.business.IErrorMessageManager;
import codecrusaders.business.impl.converters.ErrorMessageConverter;
import codecrusaders.business.impl.converters.RegrTestConverter;
import codecrusaders.business.impl.converters.TestSetConverter;
import codecrusaders.business.impl.converters.TestStepConverter;
import codecrusaders.domain.*;
import codecrusaders.repository.ErrorMessageRepository;
import codecrusaders.repository.TestStepRepository;
import codecrusaders.repository.entity.ErrorEntity;
import codecrusaders.repository.entity.RegressionTestEntity;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
@AllArgsConstructor
public class ErrorMessageManager implements IErrorMessageManager {
    private final ErrorMessageRepository errorMessageRepository;
    private final TestStepRepository testStepRepository;

    @Override
    public CreateErrorResponse createError(CreateErrorRequest request){
        Optional<ErrorEntity> savedError = saveNewError(request);
        return savedError.map(errorEntity -> CreateErrorResponse.builder().errorId(errorEntity.getErrorid()).build()).orElse(null);
    }
    private Optional<ErrorEntity> saveNewError(CreateErrorRequest request){
        ErrorEntity newError = ErrorEntity.builder()
                .errorMessage(request.getMessage())
                .build();
        return Optional.of(errorMessageRepository.save(newError));
    }

    @Override
    public GetErrorMessageResponse getAllErrorMessages(){
        List<ErrorMessage> errorMessages = errorMessageRepository.findAll()
                .stream()
                .map(ErrorMessageConverter::convert)
                .toList();
        return GetErrorMessageResponse.builder()
                .errorMessages(errorMessages)
                .build();
    }
    @Override
    public GetSimilarErrorsResponse getSimilarErrorMessages(long id){
        List<TestStep> testSteps = testStepRepository.getSimilarTestSteps(id)
                .stream()
                .map(TestStepConverter::convert)
                .toList();
        return GetSimilarErrorsResponse.builder()
                .testSteps(testSteps)
                .build();
    }
    @Override
    public Optional<ErrorMessage> getErrorById(long id) {
        return errorMessageRepository.findById(id).map(ErrorMessageConverter::convert);
    }
}
