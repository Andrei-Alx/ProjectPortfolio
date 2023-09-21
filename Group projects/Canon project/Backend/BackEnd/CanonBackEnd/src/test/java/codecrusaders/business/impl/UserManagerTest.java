package codecrusaders.business.impl;

import codecrusaders.domain.*;
import codecrusaders.domain.Http.GetAllUsersResponse;
import codecrusaders.domain.Http.RegisterUserRequest;
import codecrusaders.domain.Http.RegisterUserResponse;
import codecrusaders.repository.UserRepository;
import codecrusaders.repository.entity.RoleEnum;
import codecrusaders.repository.entity.UserEntity;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.springframework.security.crypto.password.PasswordEncoder;

import java.util.List;
import java.util.Set;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
public class UserManagerTest {
    @Mock
    UserRepository userRepository;
    @Mock
    PasswordEncoder passwordEncoder;
    @InjectMocks
    UserManager userManager;
    //Post
    private final Long userId = 1L;
    private final RegisterUserRequest request = RegisterUserRequest.builder().username("test").password("123").build();
    private final RegisterUserResponse expectedResponse = RegisterUserResponse.builder().id(userId).build();
    private final UserEntity userEntityArgument = UserEntity.builder().userName("test").password("encoded").build();
    private final UserEntity userEntityReturn = UserEntity.builder().id(userId).userName("test").password("encoded").build();

    //Get
    private final List<User> users = List.of(new User(1L, "test", "pass"),new User(2L, "test2", "pass2"));
    private final List<UserEntity> userEntities= List.of(new UserEntity(1L, "test", "pass"),new UserEntity(2L, "test2", "pass2"));
    //

    @Test
    void shouldSaveUserWithAllFields(){
        //arrange
        when(userRepository.save(userEntityArgument)).thenReturn(userEntityReturn);
        when(passwordEncoder.encode(request.getPassword())).thenReturn("encoded");
        //act
        RegisterUserResponse actualResponse = userManager.registerUser(request);
        //assert
        assertEquals(actualResponse, expectedResponse, "Wrong response is returned");
        verify(userRepository, description("Save of repo is not called (with correct argument).")).save(userEntityArgument);
    }
    @Test
    void shouldReturnAllUsers(){
        //arrange
        when(userRepository.findAll()).thenReturn(userEntities);
        //act
        GetAllUsersResponse response = userManager.getAllUsers();
        //assert
        assertEquals(users, response.getUserList(), "Wrong list is returned by SUT.");
        verify(userRepository, description("Method finalAll of repo is not called.")).findAll();
    }
}
