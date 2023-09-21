package codecrusaders.business.impl;

import codecrusaders.domain.*;
import codecrusaders.repository.RegrTestRepository;
import codecrusaders.repository.entity.RegressionTestEntity;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.*;
@ExtendWith(MockitoExtension.class)
public class RegrTestTest {

    @Mock
    RegrTestRepository regrTestRepo;
    @InjectMocks
    RegrTestManager regrTestManager;

    private final LocalDateTime date = LocalDateTime.of(2023,10,20, 17,34,20);

    private final CreateRegrTestRequest request = CreateRegrTestRequest.builder().testSetId(1L).testdate(date).testname("test").build();
    private  final Long regrTestId = 1L;
    private final CreateRegrTestResponse expectedResponse = CreateRegrTestResponse.builder().id(regrTestId).build();
    private final RegressionTestEntity regrTestEntityArgument = RegressionTestEntity.builder().testSetId(1L).testDate(date).testName("test").build();
    final RegressionTestEntity regrTestEntityReturn = RegressionTestEntity.builder().id(regrTestId).testSetId(1L).testDate(date).testName("test").build();
    private final List<RegressionTest> regrTests = List.of(new RegressionTest(1L,"test",date,2L),new RegressionTest(3L,"test",date,4L));
    private final List<RegressionTestEntity> regressionTestEntities = List.of(new RegressionTestEntity(1L,"test",date,2L),new RegressionTestEntity(3L,"test",date,4L));
    @Test
    void shouldCreateRegrTestWithAllFields(){
        //arrange
        when(regrTestRepo.save(regrTestEntityArgument)).thenReturn(regrTestEntityReturn);


        //act
        CreateRegrTestResponse actualResponse = regrTestManager.createRegressionTest(request);

        //assert
        assertEquals(actualResponse, expectedResponse, "Wrong response is returned");
        verify(regrTestRepo, description("Save of repo is not called (with correct argument).")).save(regrTestEntityArgument);
    }
    @Test
    void shouldReturnAllRegrTests(){
        //arrange
        when(regrTestRepo.findAll()).thenReturn(regressionTestEntities);


        //act
        GetRegressionTestResponse actualResponse = regrTestManager.getAllRegrTests();

        //assert
        assertEquals(regrTests,actualResponse.getRegressionTests() , "Wrong list is returned by SUT.");
        verify(regrTestRepo, description("Method finalAll of repo is not called.")).findAll();
    }
    @Test
    void shouldGetLatestTests(){
        //arrange
        GetTestsByTestSetIdRequest request = GetTestsByTestSetIdRequest.builder().id(1L).build();
        when(regrTestRepo.getLatestTestsByTestSet(1L)).thenReturn(regressionTestEntities);


        //act
        GetLatestTestsResponse actualResponse = regrTestManager.getLatestTests(request);

        //assert
        assertEquals(regrTests,actualResponse.getLatestTests() , "Wrong list is returned by SUT.");
        verify(regrTestRepo, description("Method finalAll of repo is not called.")).getLatestTestsByTestSet(1L);
    }
    @Test
    void shouldGetTestsById(){
        //arrange
        Optional<RegressionTest> regrTest = Optional.of(RegressionTest.builder().id(regrTestId).testSetId(1L).testDate(date).testName("test").build());
        when(regrTestRepo.findById(1L)).thenReturn(Optional.ofNullable(regrTestEntityReturn));


        //act
        Optional<RegressionTest> actualResponse = regrTestManager.getTestByID(1L);

        //assert
        assertEquals(regrTest,actualResponse , "Wrong list is returned by SUT.");
        verify(regrTestRepo, description("Method finalAll of repo is not called.")).findById(1L);
    }
}
