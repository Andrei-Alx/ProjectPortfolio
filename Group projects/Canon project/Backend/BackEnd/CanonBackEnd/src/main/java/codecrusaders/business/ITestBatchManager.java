package codecrusaders.business;

import codecrusaders.domain.GetAllTestSetFromABatchRequest;
import codecrusaders.domain.GetAllTestSetFromABatchResponse;
import codecrusaders.domain.TestBatch;
import codecrusaders.domain.TestSet;

import java.util.Optional;

public interface ITestBatchManager {
    public GetAllTestSetFromABatchResponse getAllTestSetsWithBatchId(GetAllTestSetFromABatchRequest request);
    public Optional<TestBatch> findTestBatch(long testbatchid);
}
