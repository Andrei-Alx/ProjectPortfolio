package org.example.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class EmailTakenException extends ResponseStatusException{
    public EmailTakenException() { super(HttpStatus.BAD_REQUEST, "Email is already taken!"); }
}
