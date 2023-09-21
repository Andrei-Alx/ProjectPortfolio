package codecrusaders.business.impl;

import codecrusaders.domain.*;
import codecrusaders.repository.ErrorMessageRepository;
import codecrusaders.repository.TestStepRepository;
import codecrusaders.repository.entity.ErrorEntity;
import codecrusaders.repository.entity.TestStepEntity;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.util.List;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.*;
import static org.mockito.Mockito.description;
@ExtendWith(MockitoExtension.class)
public class ErrorMessageManagerTest {


    @Mock
    ErrorMessageRepository errorMessageRepository;
    @Mock
    TestStepRepository testStepRepository;
    @InjectMocks
    ErrorMessageManager errorMessageManager;
    private final CreateErrorRequest request = CreateErrorRequest.builder().message("test").build();
    private  final Long errorId = 1L;
    private final CreateErrorResponse expectedResponse = CreateErrorResponse.builder().errorId(errorId).build();
    private final ErrorEntity errorEntityArgument = ErrorEntity.builder().errorMessage("test").build();
    final ErrorEntity errorEntityReturn = ErrorEntity.builder().errorid(1L).errorMessage("test").build();


    private final List<ErrorMessage> errorMessages= List.of(new ErrorMessage(1L,"test"),new ErrorMessage(2L,"test"));
    private final List<ErrorEntity> errorEntities = List.of(new ErrorEntity(1L,"test"),new ErrorEntity(2L,"test"));
    private final List<TestStep> testSteps= List.of(new TestStep(1L,"name",1L, true,"test",1L),new TestStep(2L,"name",1L, true,"test",1L));
    private final List<TestStepEntity> testStepsEntities = List.of(new TestStepEntity(1L,"name",true, 1L,"test",1L),new TestStepEntity(2L,"name",true, 1L,"test",1L));
    @Test
    void shouldCreateError(){
        //arrange
        when(errorMessageRepository.save(errorEntityArgument)).thenReturn(errorEntityReturn);


        //act
        CreateErrorResponse actualResponse = errorMessageManager.createError(request);

        //assert
        assertEquals(actualResponse, expectedResponse, "Wrong response is returned");
        verify(errorMessageRepository, description("Save of repo is not called (with correct argument).")).save(errorEntityArgument);
    }
    @Test
    void shouldReturnAllErrors(){
        //arrange
        when(errorMessageRepository.findAll()).thenReturn(errorEntities);

        //act
        GetErrorMessageResponse actualResponse = errorMessageManager.getAllErrorMessages();

        //assert
        assertEquals(errorMessages,actualResponse.getErrorMessages() , "Wrong list is returned by SUT.");
        verify(errorMessageRepository, description("Method finalAll of repo is not called.")).findAll();
    }
    @Test
    void shouldFindById(){
        //arrange
        when(errorMessageRepository.findById(1L)).thenReturn(Optional.of(new ErrorEntity(1L, "test")));
        //act
        Optional<ErrorMessage> actualResponse = errorMessageManager.getErrorById(1L);

        //assert
        assertEquals(Optional.of(new ErrorMessage(1L, "test")),actualResponse , "Wrong list is returned by SUT.");
        verify(errorMessageRepository, description("Method finalAll of repo is not called.")).findById(1L);
    }
    @Test
    void shouldFindSimilarErrorResults(){
        //arrange
        when(testStepRepository.getSimilarTestSteps(1L)).thenReturn(testStepsEntities);
        //act
        GetSimilarErrorsResponse actualResponse = errorMessageManager.getSimilarErrorMessages(1L);

        //assert
        assertEquals(testSteps,actualResponse.getTestSteps() , "Wrong list is returned by SUT.");
        verify(testStepRepository, description("Method finalAll of repo is not called.")).getSimilarTestSteps(1L);
    }
}
