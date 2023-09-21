package codecrusaders.controller;

import codecrusaders.business.impl.TestStepManager;
import codecrusaders.domain.CreateTestStepRequest;
import codecrusaders.domain.CreateTestStepResponse;
import codecrusaders.domain.GetTestStepsResponse;
import codecrusaders.domain.TestStep;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.Optional;

@RestController
@RequestMapping("/TestSteps")
@AllArgsConstructor
@CrossOrigin(origins = "http://localhost:3000/", allowedHeaders = "*", methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE, RequestMethod.PATCH})
public class TestStepController {
    private final TestStepManager testStepManager;
    @GetMapping
    public ResponseEntity<GetTestStepsResponse> getSubTests() {
        return ResponseEntity.ok(testStepManager.getTestSteps());
    }
    @PostMapping
    public ResponseEntity<CreateTestStepResponse> createTestStep(@RequestBody @Valid CreateTestStepRequest request){
        CreateTestStepResponse response = testStepManager.registerTestStep(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);

    }
    @GetMapping("/SubtestID/{subTestId}")
    public ResponseEntity<GetTestStepsResponse> getTestStepsBySubTestId(@PathVariable Long subTestId) {
        GetTestStepsResponse response = testStepManager.getTestStepBySubTestId(subTestId);
        return ResponseEntity.ok(response);
    }

    @GetMapping("/{id}")
    public ResponseEntity<TestStep> getTestStepById(@PathVariable Long id) {
        Optional<TestStep> testStepOptional = testStepManager.getTestStepById(id);

        if (testStepOptional.isPresent()) {
            return ResponseEntity.ok(testStepOptional.get());
        } else {
            return ResponseEntity.notFound().build();
        }
    }
}
