package codecrusaders.controller;

import codecrusaders.business.IBranchManager;
import codecrusaders.configuration.security.isauthenticated.IsAuthenticated;
import codecrusaders.domain.Branch;
import codecrusaders.domain.GetAllTestBatchesFromABranchRequest;
import codecrusaders.domain.GetAllTestBatchesFromABranchResponse;
import codecrusaders.domain.Http.*;
import codecrusaders.domain.TestBatch;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/Branches")
@AllArgsConstructor
@CrossOrigin(origins = "http://localhost:3000/", allowedHeaders = "*", methods = {RequestMethod.GET, RequestMethod.POST, RequestMethod.PUT, RequestMethod.DELETE, RequestMethod.PATCH})
public class BranchController {
    private final IBranchManager branchManager;

    @PostMapping()
    public ResponseEntity<RegisterBranchResponse> createBranch(@RequestBody @Valid RegisterBranchRequest request){
        RegisterBranchResponse response = branchManager.registerBranch(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }
    @GetMapping
    public ResponseEntity<GetAllBranchesResponse> getAllBranches(){
        GetAllBranchesResponse response = branchManager.getAllPublicBranches();
        return ResponseEntity.ok(response);
    }

    @IsAuthenticated
    @GetMapping("/private")
    public ResponseEntity<GetAllBranchesResponse> getAllPrivateBranches(){
        GetAllBranchesResponse response = branchManager.getAllPrivateBranches();
        return ResponseEntity.ok(response);
    }
    @GetMapping("{id}")
    public ResponseEntity<GetAllTestBatchesFromABranchResponse> getAllTestBatchesByBranchId(@PathVariable Long id){
        GetAllTestBatchesFromABranchResponse response = branchManager.getAllTestBatchesFromABranch(GetAllTestBatchesFromABranchRequest.builder().branchId(id).build());
        return ResponseEntity.ok(response);
    }

    @GetMapping("/individual/{branchid}")
    public ResponseEntity<Branch> GetBranchByIDResponse(@PathVariable(value = "branchid") final long id) {
        final Optional<Branch> branchOptional = branchManager.findById(id);
        if (branchOptional.isEmpty()) {
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(branchOptional.get());
    }


}
