package org.example.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class InvalidLinkException extends ResponseStatusException{
    public InvalidLinkException() { super(HttpStatus.BAD_REQUEST, "INVALID_LINK"); }

    public InvalidLinkException(String errorCode) {
        super(HttpStatus.BAD_REQUEST, errorCode);
    }
}
