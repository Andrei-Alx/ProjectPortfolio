package codecrusaders.controller;

import codecrusaders.business.impl.TestSetManager;
import codecrusaders.domain.*;
import lombok.AllArgsConstructor;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.Optional;
@RestController
@RequestMapping("/TestSets")
@AllArgsConstructor
@CrossOrigin(origins = "http://localhost:3000/", allowedHeaders = "*", methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE, RequestMethod.PATCH})
public class TestSetController {
    private TestSetManager testSetManager;
    @PostMapping()
    public ResponseEntity<CreateTestSetResponse> createTestSet(@RequestBody @Valid CreateTestSetRequest request) {
        CreateTestSetResponse response = testSetManager.createTestSet(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }
    @CrossOrigin(origins = "http://localhost:8080/")
    @GetMapping
    public ResponseEntity<GetTestSetResponse> getTestSets(){
        return ResponseEntity.ok(testSetManager.getAllTestSets());
    }

    @GetMapping("{id}")
    public ResponseEntity<GetTestsByTestSetIdResponse> getAllTestsByTestSetId(@PathVariable Long id){
        GetTestsByTestSetIdResponse response = testSetManager.getTestsByTestSetsId(GetTestsByTestSetIdRequest.builder().id(id).build());
        return ResponseEntity.ok(response);
    }


    @GetMapping("/individual/{testsetid}")
    public ResponseEntity<TestSet> GetTestByIDResponse(@PathVariable(value = "testsetid") final long id) {
        final Optional<TestSet> testsetOptional = testSetManager.findTestSet(id);
        if (testsetOptional.isEmpty()) {
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(testsetOptional.get());
    }




    @GetMapping("/failedCounter/{id}")
    public ResponseEntity<CountFailedTestStepResponse> getFailedCounterOfATest(@PathVariable Long id){
        CountFailedTestStepResponse response = testSetManager.countFailedTestStep(CountFailedTestStepRequest.builder().id(id).build());
        return ResponseEntity.ok(response);
    }

    @GetMapping("/totalCounter/{id}")
    public ResponseEntity<CountFailedTestStepResponse> getAllCounterOfATest(@PathVariable Long id) {
        CountFailedTestStepResponse response = testSetManager.countTotalTestStep(CountFailedTestStepRequest.builder().id(id).build());
        return ResponseEntity.ok(response);
    }

    @GetMapping("/latest")
    public ResponseEntity<GetLatestTestSetsResponse> getLatestRegrTests(){
        return ResponseEntity.ok(testSetManager.getLatestTestSets());
    }
}
