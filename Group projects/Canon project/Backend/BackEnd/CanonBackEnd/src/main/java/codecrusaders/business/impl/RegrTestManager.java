package codecrusaders.business.impl;

import codecrusaders.business.IRegressionTestManager;
import codecrusaders.business.impl.converters.RegrTestConverter;
import codecrusaders.domain.*;
import codecrusaders.repository.RegrTestRepository;
import codecrusaders.repository.TestSetRepository;
import codecrusaders.repository.entity.RegressionTestEntity;
import codecrusaders.repository.entity.TestSetEntity;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
@Service
@AllArgsConstructor
public class RegrTestManager implements IRegressionTestManager {

    private final RegrTestRepository regrTestRepo;
    @Override
    public CreateRegrTestResponse createRegressionTest(CreateRegrTestRequest request){
        Optional<RegressionTestEntity> savedRegrTest = saveNewRegrTest(request);
        return savedRegrTest.map(testSetEntity -> CreateRegrTestResponse.builder().id(testSetEntity.getId()).build()).orElse(null);
    }
    private Optional<RegressionTestEntity> saveNewRegrTest(CreateRegrTestRequest request){
        RegressionTestEntity newRegrTest = RegressionTestEntity.builder()
                .testName(request.getTestname())
                .testDate(request.getTestdate())
                .testSetId(request.getTestSetId())
                .build();
        return Optional.of(regrTestRepo.save(newRegrTest));
    }

    @Override
    public GetRegressionTestResponse getAllRegrTests(){
        List<RegressionTest> regressionTests = regrTestRepo.findAll()
                .stream()
                .map(RegrTestConverter::convert)
                .toList();
        return GetRegressionTestResponse.builder()
                .regressionTests(regressionTests)
                .build();
    }

    @Override
    public Optional<RegressionTest> getTestByID(long testid) {


        return regrTestRepo.findById(testid).map(RegrTestConverter::convert);
    }





    public GetLatestTestsResponse getLatestTests(GetTestsByTestSetIdRequest request) {
        List<RegressionTest> latestRegressionTests = regrTestRepo.getLatestTestsByTestSet(request.getId())
                .stream()
                .map(RegrTestConverter::convert)
                .toList();
        return GetLatestTestsResponse.builder().latestTests(latestRegressionTests).build();
    }
}
