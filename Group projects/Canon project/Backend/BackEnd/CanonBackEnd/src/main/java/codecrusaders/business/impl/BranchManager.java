package codecrusaders.business.impl;

import codecrusaders.business.IBranchManager;
import codecrusaders.business.exception.BranchAlreadyExistsException;
import codecrusaders.business.impl.converters.BranchConverter;
import codecrusaders.business.impl.converters.TestBatchConverter;
import codecrusaders.business.impl.converters.TestSetConverter;
import codecrusaders.business.impl.converters.UserConverter;
import codecrusaders.domain.*;
import codecrusaders.domain.Http.*;
import codecrusaders.repository.BranchRepository;
import codecrusaders.repository.TestBatchRepository;
import codecrusaders.repository.entity.BranchEntity;
import codecrusaders.repository.entity.TestBatchEntity;
import codecrusaders.repository.entity.UserEntity;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import codecrusaders.domain.AccessToken;

import java.util.List;
import java.util.Optional;

@Service
@AllArgsConstructor
public class BranchManager implements IBranchManager {
    private final BranchRepository branchRepository;
    private final TestBatchRepository testBatchRepository;
    private AccessToken accessToken;

    @Override
    public RegisterBranchResponse registerBranch(RegisterBranchRequest request) {


        UserConverter userConverter = new UserConverter();
        BranchEntity branchEntity = saveBranch(request);
        return RegisterBranchResponse.builder()
                .id(branchEntity.getId())
                //.user(UserConverter.convert(branchEntity.getUser()))
                .build();
    }

    public BranchEntity saveBranch(RegisterBranchRequest branch){

        BranchEntity temp = BranchEntity.builder()
                .branchName(branch.getBranchName())
                .isPublic(branch.isPublic())
                .build();
        return branchRepository.save(temp);


    }
    @Override
    public GetAllBranchesResponse getAllPublicBranches(){
        List<BranchEntity> results = branchRepository.findAllPublic();

        List<Branch> branches = results
                .stream()
                .map(BranchConverter::convert)
                .toList();

        return GetAllBranchesResponse.builder()
                .branchList(branches)
                .build();
    }
    @Override
    public GetAllBranchesResponse getAllPrivateBranches(){
        List<BranchEntity> results = branchRepository.findAllPrivate(accessToken.getUserId());

        List<Branch> branches = results
                .stream()
                .map(BranchConverter::convert)
                .toList();

        return GetAllBranchesResponse.builder()
                .branchList(branches)
                .build();
    }

    @Override
    public GetAllTestBatchesFromABranchResponse getAllTestBatchesFromABranch(GetAllTestBatchesFromABranchRequest request) {
        List<TestBatchEntity> testBatchesEntityList = testBatchRepository.getAllTestBatchesByBranchEntityId(request.getBranchId());

        List<TestBatch> testBatchesList = testBatchesEntityList
                .stream()
                .map(TestBatchConverter::convert)
                .toList();

        return GetAllTestBatchesFromABranchResponse.builder()
                .testBatchList(testBatchesList)
                .build();
    }

    @Override
    public Optional<Branch> findById(long branchid) {


        return branchRepository.findById(branchid).map(BranchConverter::convert);
    }


}
