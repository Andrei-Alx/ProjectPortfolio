package org.example.business.impl;

import org.example.business.IEmailValidator;
import org.example.business.exception.InvalidEmailException;
import org.example.controller.domain.post.UpdatePostVisibilityRequest;
import org.example.controller.domain.user.*;
import org.example.domain.User;
import org.example.persistance.UserRepository;
import org.example.persistance.entity.PostEntity;
import org.example.persistance.entity.UserEntity;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.security.crypto.password.PasswordEncoder;

import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
class UserManagerTest{
    @Mock
    private UserRepository userRepositoryMock;
    @Mock
    private IEmailValidator emailValidator;
    @Mock
    private PasswordEncoder passwordEncoder;
    @InjectMocks
    private UserManager userManager;
    String validEmail = "test@mail.com";
    String invalidEmail = "invalidMail";
    String password = "123";

    @Test
    void createUserValidEmail(){
        CreateUserRequest request = new CreateUserRequest(validEmail, 1, password);
        when(emailValidator.isValidEmail(validEmail)).thenReturn(true);

        UserEntity savedUser = new UserEntity(1L, validEmail, 1, password,"Active");
        when(userRepositoryMock.save(any(UserEntity.class))).thenReturn(savedUser);

        CreateUserResponse response = userManager.createUser(request);
        assertEquals(1L, (long) response.getUserId());
        verify(userRepositoryMock, times(1)).save(any(UserEntity.class));
    }
    @Test
    public void testCreateUserInvalidEmail() {
        // Arrange
        CreateUserRequest request = new CreateUserRequest(invalidEmail, 1, password);
        // Act
        when(emailValidator.isValidEmail(invalidEmail)).thenReturn(false);

        // Assert
        assertThrows(InvalidEmailException.class, () -> userManager.createUser(request));
        verify(emailValidator, times(1)).isValidEmail(invalidEmail);
    }
    @Test
    void testGetUsers(){
        UserEntity savedUser = new UserEntity(1L, validEmail, 1, password,"Active");
        UserEntity savedUser1 = new UserEntity(1L, validEmail, 1, password, "Active");

        when(userRepositoryMock.findAll()).thenReturn(List.of(savedUser, savedUser1));

        ReadAllUsersResponse actualResult = userManager.getUsers();
        User expectedSavedUser = new User(1L, validEmail, 1, password,"Active");
        User expectedSavedUser1 = new User(1L, validEmail, 1, password,"Active");
        ReadAllUsersResponse expectedResult = ReadAllUsersResponse.builder().users(List.of(expectedSavedUser, expectedSavedUser1)).build();

        assertEquals(expectedResult, actualResult);
        verify(userRepositoryMock, times(1)).findAll();
    }
    @Test
    void testGetPlayers(){
        UserEntity savedUser = new UserEntity(1L, validEmail, 1, password,"Active");
        UserEntity savedUser1 = new UserEntity(1L, validEmail, 1, password,"Active");

        when(userRepositoryMock.findUserEntitiesByUserRoleIsLike(1)).thenReturn(List.of(savedUser, savedUser1));

        ReadAllUsersResponse actualResult = userManager.getPlayers();
        User expectedSavedUser = new User(1L, validEmail, 1, password,"Active");
        User expectedSavedUser1 = new User(1L, validEmail, 1, password,"Active");
        ReadAllUsersResponse expectedResult = ReadAllUsersResponse.builder().users(List.of(expectedSavedUser, expectedSavedUser1)).build();

        assertEquals(expectedResult, actualResult);
        verify(userRepositoryMock, times(1)).findUserEntitiesByUserRoleIsLike(1);
    }
    @Test
    void testGetPlayerCount(){
        UserEntity savedUser = new UserEntity(1L, validEmail, 1, password,"Active");
        UserEntity savedUser1 = new UserEntity(1L, validEmail, 1, password,"Active");

        when(userRepositoryMock.getAllUsersCount()).thenReturn(2);
        ReadUserCountResponse actualResult = userManager.getUserCount();
        User expectedSavedUser = new User(1L, validEmail, 1, password,"Active");
        User expectedSavedUser1 = new User(1L, validEmail, 1, password,"Active");
        ReadUserCountResponse expectedResult = ReadUserCountResponse.builder().userCount(2).build();

        assertEquals(expectedResult, actualResult);
        verify(userRepositoryMock, times(1)).getAllUsersCount();
    }
    @Test
    void testDeleteUser(){
        long userId = 1L;
        userManager.deleteUser(userId);
        verify(userRepositoryMock, times(1)).deleteById(userId);
    }

    @Test
    void updateAccountStatus() {
        //Arrange
        UpdateUserAccountStatus request = new UpdateUserAccountStatus();
        request.setId(1L);
        request.setNewStatus("Inactive");

        UserEntity userEntity = new UserEntity(1L, validEmail, 1, password,"Active");

//Act
        when(userRepositoryMock.findById(1L)).thenReturn(userEntity);

        userManager.updateAccountStatus(request);

//Assert
        assertEquals(request.getNewStatus(), userEntity.getIsUserActive());

        verify(userRepositoryMock, times(1)).findById(1L);
        verify(userRepositoryMock, times(1)).save(userEntity);
    }
}