package codecrusaders.business.impl;

import codecrusaders.business.impl.converters.SubTestConverter;
import codecrusaders.domain.*;
import codecrusaders.repository.SubTestRepository;
import codecrusaders.repository.entity.SubTestEntity;
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
public class SubTestTest {


    @Mock
    SubTestRepository subTestRepository;
    @InjectMocks
    SubTestManager subTestManager;


    private final CreateSubTestRequest request = CreateSubTestRequest.builder().testId(1L).subtestname("test").build();
    private  final Long subTestId = 1L;
    private final CreateSubTestResponse expectedResponse = CreateSubTestResponse.builder().subTestId(subTestId).build();
    private final SubTestEntity subTestEntityArgument = SubTestEntity.builder().testID(1L).subTestName("test").build();
    final SubTestEntity subTestEntityReturn = SubTestEntity.builder().testID(1L).subTestName("test").id(subTestId).build();
    private final List<SubTest> subTests = List.of(new SubTest(1L,"test",1L),new SubTest(3L,"test",1L));
    private final List<SubTestEntity> subTestEntities = List.of(new SubTestEntity(1L,"test",1L),new SubTestEntity(3L,"test",1L));
    @Test
    void shouldCreateSubTestWithAllFields(){
        //arrange
        //SubTestRepository repository = mock(SubTestRepository.class);
        when(subTestRepository.save(subTestEntityArgument)).thenReturn(subTestEntityReturn);

        //SubTestManager manager = new SubTestManager(repository);

        //act
        CreateSubTestResponse actualResponse = subTestManager.registerSubTest(request);

        //assert
        assertEquals(actualResponse, expectedResponse, "Wrong response is returned");
        verify(subTestRepository, description("Save of repo is not called (with correct argument).")).save(subTestEntityArgument);
    }
    @Test
    void shouldReturnAllSubTests(){
        //arrange
        //SubTestRepository repository = mock(SubTestRepository.class);
        when(subTestRepository.findAll()).thenReturn(subTestEntities);

        //SubTestManager manager = new SubTestManager(repository);

        //act
        GetSubTestsResponse actualResponse = subTestManager.getSubTests();

        //assert
        assertEquals(subTests,actualResponse.getSubTests() , "Wrong list is returned by SUT.");
        verify(subTestRepository, description("Method finalAll of repo is not called.")).findAll();
    }

    @Test
    void shouldCountFailedSteps(){
        CountFailedTestStepRequest request = CountFailedTestStepRequest.builder().id(1L).build();
        CountFailedTestStepResponse eResponse = CountFailedTestStepResponse.builder().failedCounter(0).build();

        CountFailedTestStepResponse response = subTestManager.countFailedTestStep(request);

        assertEquals(eResponse, response, "Wrong response is returned");
        verify(subTestRepository, description("Save of repo is not called (with correct argument).")).countFailedTestStepsBySubTestID(1L);
    }

    @Test
    void shouldGetSubTestsById(){
        GetSubTestsResponse response = GetSubTestsResponse.builder().subTests(subTests).build();
        when(subTestRepository.findByTestID(1L)).thenReturn(subTestEntities);
        GetSubTestsResponse response2 = subTestManager.getSubTestsByTestID(1L);

        assertEquals(response2, response, "Wrong response is returned");
        verify(subTestRepository, description("Save of repo is not called (with correct argument).")).findByTestID(1L);
    }

    @Test
    void shouldFindById(){
        SubTestEntity se = new SubTestEntity(1L,"test",1L);
        Optional<SubTest> s = Optional.of(new SubTest(1L,"test",1L));
        when(subTestRepository.findById(1L)).thenReturn(Optional.of(se));
        Optional<SubTest> response = subTestManager.findById(1L);

        assertEquals(response, s, "Wrong response is returned");
        verify(subTestRepository, description("Save of repo is not called (with correct argument).")).findById(1L);
    }

}
