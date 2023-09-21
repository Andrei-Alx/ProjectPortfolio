package codecrusaders.business.impl;

import codecrusaders.business.IUserManager;
import codecrusaders.business.exception.AccountAlreadyExistsException;
import codecrusaders.business.impl.converters.UserConverter;
import codecrusaders.domain.AccessToken;
import codecrusaders.domain.Http.GetAllUsersResponse;
import codecrusaders.domain.Http.RegisterUserRequest;
import codecrusaders.domain.Http.RegisterUserResponse;
import codecrusaders.domain.User;
import codecrusaders.repository.UserRepository;
import codecrusaders.repository.entity.UserEntity;
import lombok.AllArgsConstructor;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@AllArgsConstructor
public class UserManager implements IUserManager {

    private final UserRepository userRepository;
    private final PasswordEncoder passwordEncoder;
    private AccessToken requestAccessToken;
    @Override
    public RegisterUserResponse registerUser(RegisterUserRequest request) {

        UserEntity user = userRepository.findByUserName(request.getUsername());

        if(user != null){{
            throw new AccountAlreadyExistsException();
        }}



        UserEntity userEntity = saveUser(request, request.getPassword());

        return RegisterUserResponse.builder()
                .id(userEntity.getId())
                .build();
    }

    public UserEntity saveUser(RegisterUserRequest user, String password){
        String encodedPassword = passwordEncoder.encode(password);
        UserEntity temp = UserEntity.builder()
                .userName(user.getUsername())
                .password(encodedPassword)
                .build();
        return userRepository.save(temp);

    }

    public GetAllUsersResponse getAllUsers(){
        List<UserEntity> results;

        results = userRepository.findAll();

        List<User> users = results
                .stream()
                .map(UserConverter::convert)
                .toList();

        return GetAllUsersResponse.builder()
                .userList(users)
                .build();
    }
}
