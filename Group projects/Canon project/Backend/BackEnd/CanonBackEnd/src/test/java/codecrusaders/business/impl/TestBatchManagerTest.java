package codecrusaders.business.impl;


import codecrusaders.domain.*;
import codecrusaders.repository.TestBatchRepository;
import codecrusaders.repository.TestSetRepository;
import codecrusaders.repository.entity.TestBatchEntity;
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
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
public class TestBatchManagerTest {


    @Mock
    TestBatchRepository testBatchRepository;
    @Mock
    TestSetRepository testSetRepository;
    @InjectMocks
    TestBatchManager testBatchManager;


    @Test
    void shouldGetAllTestSetsWithBatchId(){
        Date date = null;
        GetAllTestSetFromABatchRequest request = GetAllTestSetFromABatchRequest.builder().testBatchId(1L).build();
        List<TestSet> testSets = List.of(new TestSet(1L,"test",1L,date),new TestSet(2L,"test",1L,date));
        List<TestSetEntity> testSetEntities = List.of(new TestSetEntity(1L,"test",1L,date),new TestSetEntity(2L,"test",1L,date));
        when(testSetRepository.getAllTestSetsByBatchId(1L)).thenReturn(testSetEntities);

        GetAllTestSetFromABatchResponse response = testBatchManager.getAllTestSetsWithBatchId(request);

        assertEquals(testSets, response.getTestSetList(), "Wrong list is returned by SUT.");
    }
    @Test
    void shouldFindTestBatch(){
        LocalDateTime date = null;
        Optional<TestBatch> t = Optional.of(TestBatch.builder().id(1L).branchId(1L).buildTime("Test").dateTime(date).commitShal("test").version("test").build());
        when(testBatchRepository.findById(1L)).thenReturn(Optional.of(new TestBatchEntity(1L, "Test", "test", "test", date, 1L)));
        Optional<TestBatch> response = testBatchManager.findTestBatch(1L);
        assertEquals(t, response, "Wrong response is returned.");
        verify(testBatchRepository, description("Correct method of repo is not called.")).findById(1L);
    }

}
