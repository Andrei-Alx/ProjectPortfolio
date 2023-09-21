package codecrusaders.business.exception;

import codecrusaders.repository.BranchRepository;
import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class BranchAlreadyExistsException extends ResponseStatusException {
    public BranchAlreadyExistsException(){super(HttpStatus.BAD_REQUEST,"Branch already exists");}
}
