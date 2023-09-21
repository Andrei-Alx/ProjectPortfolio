package codecrusaders.controller;
import codecrusaders.business.impl.RegrTestManager;
import codecrusaders.business.impl.TestSetManager;
import codecrusaders.domain.*;
import lombok.AllArgsConstructor;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

import javax.annotation.security.RolesAllowed;
import javax.validation.Valid;
import java.util.Optional;

@RestController
@RequestMapping("/Tests")
@AllArgsConstructor
@CrossOrigin(origins = "http://localhost:3000/", allowedHeaders = "*", methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE, RequestMethod.PATCH})
public class RegressionTestController {
    private RegrTestManager regrTestManager;
    @PostMapping()
    public ResponseEntity<CreateRegrTestResponse> createRegrTest(@RequestBody @Valid CreateRegrTestRequest request) {
        CreateRegrTestResponse response = regrTestManager.createRegressionTest(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }
    @GetMapping
    public ResponseEntity<GetRegressionTestResponse> getRegrTests(){
        return ResponseEntity.ok(regrTestManager.getAllRegrTests());
    }
    @GetMapping("{id}")
    public ResponseEntity<RegressionTest> GetTestByIDResponse(@PathVariable(value = "id") final long id) {
        final Optional<RegressionTest> testOptional = regrTestManager.getTestByID(id);
        if (testOptional.isEmpty()) {
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(testOptional.get());
    }

    @GetMapping("/latest/{id}")
    public ResponseEntity<GetLatestTestsResponse> getLatestRegrTestsByTestSetId(@PathVariable Long id){
        GetTestsByTestSetIdRequest request = GetTestsByTestSetIdRequest.builder().id(id).build();
        return ResponseEntity.ok(regrTestManager.getLatestTests(request));
    }
}
