package codecrusaders.business.impl;

import codecrusaders.domain.*;
import codecrusaders.repository.RegrTestRepository;
import codecrusaders.repository.TestSetRepository;
import codecrusaders.repository.entity.RegressionTestEntity;
import codecrusaders.repository.entity.TestSetEntity;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.*;
@ExtendWith(MockitoExtension.class)
public class TestSetTest {

    @Mock
     RegrTestRepository regTestRepo;
    @Mock
     TestSetRepository testSetRepo;
    @InjectMocks
    TestSetManager testSetManager;

    private final Date date = null;
    private final CreateTestSetRequest request = CreateTestSetRequest.builder().testBatchId(1L).testSetTime(date).testSetName("test").build();
    private  final Long testSetId = 1L;
    private final CreateTestSetResponse expectedResponse = CreateTestSetResponse.builder().id(testSetId).build();
    private final TestSetEntity testSetEntityArgument = TestSetEntity.builder().testBatchId(1L).testSetTime(date).testSetName("test").build();
    final TestSetEntity testSetEntityReturn = TestSetEntity.builder().id(testSetId).testBatchId(1L).testSetTime(date).testSetName("test").build();
    private final List<TestSet> testSets = List.of(new TestSet(1L,"test",1L,date),new TestSet(2L,"test",1L,date));
    private final List<TestSetEntity> testSetEntities = List.of(new TestSetEntity(1L,"test",1L,date),new TestSetEntity(2L,"test",1L,date));
    @Test
    void shouldCreateTestSetWithAllFields(){
        //arrange
        //TestSetRepository repository = mock(TestSetRepository.class);
        when(testSetRepo.save(testSetEntityArgument)).thenReturn(testSetEntityReturn);

       // TestSetManager manager = new TestSetManager(repository);

        //act
        CreateTestSetResponse actualResponse = testSetManager.createTestSet(request);

        //assert
        assertEquals(actualResponse, expectedResponse, "Wrong response is returned");
        verify(testSetRepo, description("Save of repo is not called (with correct argument).")).save(testSetEntityArgument);
    }
    @Test
    void shouldReturnAllTestSets(){
        //arrange
        //TestSetRepository repository = mock(TestSetRepository.class);
        when(testSetRepo.findAll()).thenReturn(testSetEntities);

        //TestSetManager manager = new TestSetManager(repository);

        //act
        GetTestSetResponse actualResponse = testSetManager.getAllTestSets();

        //assert
        assertEquals(testSets,actualResponse.getTestSets() , "Wrong list is returned by SUT.");
        verify(testSetRepo, description("Method finalAll of repo is not called.")).findAll();
    }
    @Test
    void shouldFindTest(){
        //arrange
        Optional<TestSet> t = Optional.of(TestSet.builder().id(testSetId).testBatchId(1L).testSetTime(date).name("test").build());
        when(testSetRepo.findById(1L)).thenReturn(Optional.ofNullable(testSetEntityReturn));

        //act
        Optional<TestSet> actualResponse = testSetManager.findTestSet(1L);

        //assert
        assertEquals(t,actualResponse , "Wrong response is returned.");
        verify(testSetRepo, description("Method findById of repo is not called.")).findById(1L);
    }
    @Test
    void shouldGetLatestTestSets(){
        //arrange
        GetLatestTestSetsResponse response = GetLatestTestSetsResponse.builder().latestTestSets(testSets).build();
        when(testSetRepo.findLatestTestSets()).thenReturn(testSetEntities);

        //act
        GetLatestTestSetsResponse actualResponse = testSetManager.getLatestTestSets();

        //assert
        assertEquals(response,actualResponse , "Wrong response is returned.");
        verify(testSetRepo, description("Method findById of repo is not called.")).findLatestTestSets();
    }
    @Test
    void shouldTestByTestSetId(){
        //arrange
        List<RegressionTest> regressionTests = List.of(new RegressionTest(1L,"test",LocalDateTime.of(2023,10,20, 17,34,20),1L));
        List<RegressionTestEntity> regressionTestEntities = List.of(new RegressionTestEntity(1L,"test",LocalDateTime.of(2023,10,20, 17,34,20),1L));
        GetTestsByTestSetIdRequest id = GetTestsByTestSetIdRequest.builder().id(1L).build();
        GetTestsByTestSetIdResponse response = GetTestsByTestSetIdResponse.builder().regressionTests(regressionTests).build();
        when(regTestRepo.getTestsByTestSetId(id.getId())).thenReturn(regressionTestEntities);

        //act
        GetTestsByTestSetIdResponse actualResponse = testSetManager.getTestsByTestSetsId(id);

        //assert
        assertEquals(response,actualResponse , "Wrong response is returned.");
        verify(regTestRepo, description("Method findById of repo is not called.")).getTestsByTestSetId(1L);
    }
}
