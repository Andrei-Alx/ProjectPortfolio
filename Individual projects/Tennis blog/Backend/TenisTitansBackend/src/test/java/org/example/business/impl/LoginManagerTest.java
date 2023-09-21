package org.example.business.impl;

import org.example.business.AccessTokenEncoder;
import org.example.business.exception.InvalidCredentialsException;
import org.example.business.exception.UnauthorizedAccessException;
import org.example.controller.domain.AccessToken;
import org.example.controller.domain.login.LoginRequest;
import org.example.controller.domain.login.LoginResponse;
import org.example.persistance.UserRepository;
import org.example.persistance.entity.UserEntity;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.MockitoAnnotations;
import org.springframework.security.crypto.password.PasswordEncoder;

public class LoginManagerTest {

    @Mock
    private UserRepository userRepository;

    @Mock
    private PasswordEncoder passwordEncoder;

    @Mock
    private AccessTokenEncoder accessTokenEncoder;

    @InjectMocks
    private LoginManager loginManager;

    @BeforeEach
    void setUp() {
        MockitoAnnotations.openMocks(this);
    }

    @Test
    public void testLogin() {
        String email = "test@example.com";
        String password = "password";
        String encodedPassword = "encodedPassword";
        String accessToken = "accessToken";

        UserEntity user = new UserEntity();
        user.setEmail(email);
        user.setPassword(encodedPassword);
        user.setIsUserActive("Active");

        Mockito.when(userRepository.findByEmail(email)).thenReturn(user);
        Mockito.when(passwordEncoder.matches(password, encodedPassword)).thenReturn(true);
        Mockito.when(accessTokenEncoder.encode(Mockito.any(AccessToken.class))).thenReturn(accessToken);

        LoginRequest loginRequest = new LoginRequest(email, password);
        LoginResponse loginResponse = loginManager.login(loginRequest);

        Assertions.assertNotNull(loginResponse);
        Assertions.assertEquals(accessToken, loginResponse.getAccessToken());
    }

    @Test
    public void testLoginInvalidCredentials() {
        String email = "test@example.com";
        String password = "password";
        String encodedPassword = "encodedPassword";

        UserEntity user = new UserEntity();
        user.setEmail(email);
        user.setPassword(encodedPassword);
        user.setIsUserActive("Active");


        Mockito.when(userRepository.findByEmail(email)).thenReturn(user);
        Mockito.when(passwordEncoder.matches(password, encodedPassword)).thenReturn(false);

        LoginRequest loginRequest = new LoginRequest(email, password);
        Assertions.assertThrows(InvalidCredentialsException.class, () -> {
            loginManager.login(loginRequest);
        });
    }

    @Test
    public void testLoginUserNotFound() {
        String email = "test@example.com";
        String password = "password";

        Mockito.when(userRepository.findByEmail(email)).thenReturn(null);

        LoginRequest loginRequest = new LoginRequest(email, password);
        Assertions.assertThrows(UnauthorizedAccessException.class, () -> {
            loginManager.login(loginRequest);
        });
    }
}
