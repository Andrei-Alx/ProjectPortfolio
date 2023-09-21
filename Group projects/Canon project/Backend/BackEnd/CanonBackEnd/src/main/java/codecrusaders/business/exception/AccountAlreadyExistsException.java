package codecrusaders.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class AccountAlreadyExistsException extends ResponseStatusException {
    public AccountAlreadyExistsException(){super(HttpStatus.BAD_REQUEST,"Account already exists");}
}
