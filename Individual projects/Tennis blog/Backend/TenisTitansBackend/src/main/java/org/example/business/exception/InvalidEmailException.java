package org.example.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class InvalidEmailException extends ResponseStatusException {
    public InvalidEmailException() { super(HttpStatus.BAD_REQUEST, "INVALID_EMAIL"); }
}
