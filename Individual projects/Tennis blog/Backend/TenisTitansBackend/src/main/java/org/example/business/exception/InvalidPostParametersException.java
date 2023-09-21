package org.example.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class InvalidPostParametersException extends ResponseStatusException {
    public InvalidPostParametersException(String errorCode) {
        super(HttpStatus.BAD_REQUEST, errorCode);
    }
}
