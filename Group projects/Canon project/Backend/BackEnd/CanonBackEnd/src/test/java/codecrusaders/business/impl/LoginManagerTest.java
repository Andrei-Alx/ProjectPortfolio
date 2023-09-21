package codecrusaders.business.impl;

import codecrusaders.business.AccessTokenEncoder;
import codecrusaders.business.exception.InvalidCredentialsException;
import codecrusaders.domain.*;
import codecrusaders.domain.LoginRequest;
import codecrusaders.domain.LoginResponse;
import codecrusaders.repository.UserRepository;
import codecrusaders.repository.entity.RoleEnum;
import codecrusaders.repository.entity.UserEntity;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.security.crypto.password.PasswordEncoder;

import java.util.Set;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
public class LoginManagerTest {
    @Mock
    UserRepository userRepository;
    @Mock
    PasswordEncoder passwordEncoder;
    @Mock
    AccessTokenEncoder accessTokenEncoder;
    @InjectMocks
    LoginManager loginManager;


    @Test
    void shouldLogin(){
        //arrange
        LoginRequest loginRequest = new LoginRequest("username", "password");
        UserEntity userEntity = new UserEntity();
        userEntity.setId(1L);
        userEntity.setUserName("username");
        userEntity.setPassword("encodedPassword");

        when(userRepository.findByUserName(anyString())).thenReturn(userEntity);
        when(passwordEncoder.matches(anyString(), anyString())).thenReturn(true);
        when(accessTokenEncoder.encode(any())).thenReturn("accessToken");

        // Act
        LoginResponse loginResponse = loginManager.login(loginRequest);

        // Assert
        assertNotNull(loginResponse);
        assertEquals("accessToken", loginResponse.getAccessToken());

        verify(userRepository, times(1)).findByUserName("username");
        verify(passwordEncoder, times(1)).matches("password", "encodedPassword");
        verify(accessTokenEncoder, times(1)).encode(any());
    }
    @Test
    public void testLoginInvalidUsername() {
        // Arrange
        LoginRequest loginRequest = new LoginRequest("nonexistentUser", "password");

        when(userRepository.findByUserName(anyString())).thenReturn(null);

        // Act & Assert
        assertThrows(InvalidCredentialsException.class, () -> {
            loginManager.login(loginRequest);
        });

        verify(userRepository, times(1)).findByUserName("nonexistentUser");
        verifyNoMoreInteractions(passwordEncoder);
        verifyNoMoreInteractions(accessTokenEncoder);
    }

    @Test
    public void testLoginInvalidPassword() {
        // Arrange
        LoginRequest loginRequest = new LoginRequest("username", "wrongPassword");
        UserEntity userEntity = new UserEntity();
        userEntity.setUserName("username");
        userEntity.setPassword("encodedPassword");

        when(userRepository.findByUserName(anyString())).thenReturn(userEntity);
        when(passwordEncoder.matches(anyString(), anyString())).thenReturn(false);

        // Act & Assert
        assertThrows(InvalidCredentialsException.class, () -> {
            loginManager.login(loginRequest);
        });

        verify(userRepository, times(1)).findByUserName("username");
        verify(passwordEncoder, times(1)).matches("wrongPassword", "encodedPassword");
        verifyNoMoreInteractions(accessTokenEncoder);
    }
}
