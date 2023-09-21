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
@ExtendWith(MockitoExtension.class)
public class TestStepTest {

    @Mock
    TestStepRepository testStepRepository;
    @Mock
    ErrorMessageRepository errorMessageRepository;
    @InjectMocks
    TestStepManager testStepManager;
    private final ErrorMessage em = ErrorMessage.builder().id(1L).message("test").build();
    private final ErrorEntity eme = ErrorEntity.builder().errorid(1L).errorMessage("test").build();

    private final ErrorMessage em2 = ErrorMessage.builder().message("test").build();
    private final CreateTestStepRequest request = CreateTestStepRequest.builder().subTestID(1L).testResult(true).description("test").subTestID(em.getId()).testStepName("name").build();
    private  final Long testStepId = 1L;
    private final CreateTestStepResponse expectedResponse = CreateTestStepResponse.builder().testStepId(testStepId).build();
    private final TestStepEntity testStepEntityArgument = TestStepEntity.builder().subTestID(1L).testResult(true).testStepName("name").description("test").errorID(0L).build();
    final TestStepEntity testStepEntityReturn = TestStepEntity.builder().id(testStepId).subTestID(1L).testResult(true).testStepName("name").description("test").errorID(0L).build();


    private final List<TestStep> testSteps= List.of(new TestStep(1L,"name",1L, true,"test",1L),new TestStep(2L,"name",1L, true,"test",1L));
    private final List<TestStepEntity> testStepsEntities = List.of(new TestStepEntity(1L,"name",true, 1L,"test",1L),new TestStepEntity(2L,"name",true, 1L,"test",1L));
    @Test
    void shouldCreateTestStepWithAllFields(){
        //arrange
        when(testStepRepository.save(testStepEntityArgument)).thenReturn(testStepEntityReturn);


        //act
        CreateTestStepResponse actualResponse = testStepManager.registerTestStep(request);

        //assert
        assertEquals(actualResponse, expectedResponse, "Wrong response is returned");
        verify(testStepRepository, description("Save of repo is not called (with correct argument).")).save(testStepEntityArgument);
    }
    @Test
    void shouldReturnAllTestSteps(){
        //arrange

        when(testStepRepository.findAll()).thenReturn(testStepsEntities);


        //act
        GetTestStepsResponse actualResponse = testStepManager.getTestSteps();

        //assert
        assertEquals(testSteps,actualResponse.getTestSteps() , "Wrong list is returned by SUT.");
        verify(testStepRepository, description("Method finalAll of repo is not called.")).findAll();
    }
    @Test
    void shouldGetTestStepById(){
        //arrange
        Optional<TestStep> t = Optional.of(TestStep.builder().id(testStepId).subTestId(1L).testResult(true).testStepName("name").description("test").errorid(0L).build());
        when(testStepRepository.findById(1L)).thenReturn(Optional.ofNullable(testStepEntityReturn));


        //act
        Optional<TestStep> actualResponse = testStepManager.getTestStepById(1L);

        //assert
        assertEquals(actualResponse, t, "Wrong response is returned");
        verify(testStepRepository, description("Save of repo is not called (with correct argument).")).findById(1L);
    }
    @Test
    void shouldGetTestStepBySubTestId(){
        //arrange
        GetTestStepsResponse grs = GetTestStepsResponse.builder().testSteps(testSteps).build();
        when(testStepRepository.findBySubTestID(1L)).thenReturn(testStepsEntities);


        //act
        GetTestStepsResponse actualResponse = testStepManager.getTestStepBySubTestId(1L);

        //assert
        assertEquals(actualResponse, grs, "Wrong response is returned");
        verify(testStepRepository, description("Save of repo is not called (with correct argument).")).findBySubTestID(1L);
    }
}
