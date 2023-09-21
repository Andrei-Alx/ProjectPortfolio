package codecrusaders.business.impl;

import codecrusaders.business.ITestBatchManager;
import codecrusaders.business.impl.converters.TestBatchConverter;
import codecrusaders.business.impl.converters.TestSetConverter;
import codecrusaders.domain.GetAllTestSetFromABatchRequest;
import codecrusaders.domain.GetAllTestSetFromABatchResponse;
import codecrusaders.domain.TestBatch;
import codecrusaders.repository.TestBatchRepository;
import codecrusaders.repository.TestSetRepository;
import codecrusaders.repository.entity.TestSetEntity;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
@AllArgsConstructor
public class TestBatchManager implements ITestBatchManager {
    private final TestBatchRepository testBatchRepository;
    private final TestSetRepository testSetRepository;
    @Override
    public GetAllTestSetFromABatchResponse getAllTestSetsWithBatchId(GetAllTestSetFromABatchRequest request) {
        List<TestSetEntity> testSetList = testSetRepository.getAllTestSetsByBatchId(request.getTestBatchId());
        return GetAllTestSetFromABatchResponse.builder().testSetList(testSetList.stream().map(TestSetConverter::convert).toList()).build();
    }

    @Override
    public Optional<TestBatch> findTestBatch(long testbatchid) {


        return testBatchRepository.findById(testbatchid).map(TestBatchConverter::convert);
    }

}
