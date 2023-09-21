package org.example.business;

public interface IEmailValidator {
    boolean isValidEmail(String email);
    boolean isEmailTaken(String email);
}
