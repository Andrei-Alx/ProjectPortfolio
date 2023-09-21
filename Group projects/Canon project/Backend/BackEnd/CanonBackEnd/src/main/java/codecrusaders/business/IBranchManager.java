package codecrusaders.business;

import codecrusaders.domain.Branch;
import codecrusaders.domain.GetAllTestBatchesFromABranchRequest;
import codecrusaders.domain.GetAllTestBatchesFromABranchResponse;
import codecrusaders.domain.Http.GetAllBranchesResponse;
import codecrusaders.domain.Http.RegisterBranchRequest;
import codecrusaders.domain.Http.RegisterBranchResponse;
import codecrusaders.domain.TestSet;

import java.util.Optional;

public interface IBranchManager {
    //...
    public RegisterBranchResponse registerBranch(RegisterBranchRequest request);
    public GetAllBranchesResponse getAllPublicBranches();
    public GetAllBranchesResponse getAllPrivateBranches();
    public GetAllTestBatchesFromABranchResponse getAllTestBatchesFromABranch(GetAllTestBatchesFromABranchRequest request);
    Optional<Branch> findById(long branchid);

    }
