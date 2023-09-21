package codecrusaders.controller;

import codecrusaders.business.impl.ErrorMessageManager;
import codecrusaders.domain.*;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.Optional;

@RestController
@RequestMapping("/errors")
@AllArgsConstructor
@CrossOrigin(origins = "http://localhost:3000/", allowedHeaders = "*", methods = {RequestMethod.GET,RequestMethod.POST,RequestMethod.PUT,RequestMethod.DELETE})
public class ErrorMessageController {

    private ErrorMessageManager errorMessageManager;


    @PostMapping()
    public ResponseEntity<CreateErrorResponse> createError(@RequestBody @Valid CreateErrorRequest request) {
        CreateErrorResponse response = errorMessageManager.createError(request);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }
    @GetMapping
    public ResponseEntity<GetErrorMessageResponse> getAllErrors(){
        return ResponseEntity.ok(errorMessageManager.getAllErrorMessages());
    }
    @GetMapping("/{id}")
    public ResponseEntity<ErrorMessage> getErrorById(@PathVariable(value = "id") final Long id){
        final Optional<ErrorMessage> errorMessageOptional = errorMessageManager.getErrorById(id);
        if(errorMessageOptional.isEmpty()){
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok().body(errorMessageOptional.get());
    }
    @GetMapping("/similarErrors/{id}")
    public ResponseEntity<GetSimilarErrorsResponse> getSimilarErrorsById(@PathVariable(value = "id") final Long id){
        return ResponseEntity.ok(errorMessageManager.getSimilarErrorMessages(id));
    }
}
