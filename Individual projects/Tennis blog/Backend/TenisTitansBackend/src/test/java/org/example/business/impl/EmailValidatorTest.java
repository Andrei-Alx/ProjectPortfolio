package org.example.business.impl;

import org.example.persistance.UserRepository;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.junit.jupiter.api.Assertions.*;

@ExtendWith(MockitoExtension.class)
class EmailValidatorTest {
    @Mock
    UserRepository mockUserRepository;
    @InjectMocks
    EmailValidator emailValidator;

    @Test
    public void testIsValidEmail_NullMail() {
        assertFalse(emailValidator.isValidEmail(null));
    }

    @Test
    public void testIsValidEmail_ValidMail() {
        assertTrue(emailValidator.isValidEmail("test@mail.com"));
    }

    @Test
    public void testIsValidLink_InvalidMail() {
        assertFalse(emailValidator.isValidEmail("test.com"));
    }
}