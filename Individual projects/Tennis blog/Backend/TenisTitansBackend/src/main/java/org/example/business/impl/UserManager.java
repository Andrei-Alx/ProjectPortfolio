package org.example.business.impl;

import lombok.AllArgsConstructor;
import org.example.business.IEmailValidator;
import org.example.business.IUserManager;
import org.example.business.exception.EmailTakenException;
import org.example.business.exception.InvalidEmailException;
import org.example.business.exception.InvalidPostParametersException;
import org.example.controller.domain.user.*;
import org.example.domain.User;
import org.example.persistance.UserRepository;
import org.example.persistance.entity.PostEntity;
import org.example.persistance.entity.UserEntity;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
@AllArgsConstructor
public class UserManager implements IUserManager {

    private final UserRepository realUserRepository;
    private final IEmailValidator emailValidator;
    private final PasswordEncoder passwordEncoder;

    @Override
    public CreateUserResponse createUser(CreateUserRequest request) {
        if(!emailValidator.isValidEmail(request.getEmail())){
            throw new InvalidEmailException();
        }
        if(emailValidator.isEmailTaken(request.getEmail()))
        {
            throw new EmailTakenException();
        }
        UserEntity savedUser = saveNewUser(request);
        return CreateUserResponse.builder()
                .userId(savedUser.getId())
                .build();

    }
    private UserEntity saveNewUser(CreateUserRequest request){
        String encodedPassword = passwordEncoder.encode(request.getPassword());

        UserEntity newUser = UserEntity.builder()
                .email(request.getEmail())
                .userRole(request.getRole())
                .password(encodedPassword)
                .isUserActive("Active")
                .build();
        return realUserRepository.save(newUser);
    }

    @Override
    public ReadAllUsersResponse getUsers() {
        List<User> users = realUserRepository.findAll()
                .stream()
                .map(UserConvertor::convert)
                .toList();

        return ReadAllUsersResponse.builder()
                .users(users)
                .build();
    }

    @Override
    public ReadAllUsersResponse getPlayers() {
        List<User> users = realUserRepository.findUserEntitiesByUserRoleIsLike(1)
                .stream()
                .map(UserConvertor::convert)
                .toList();

        return ReadAllUsersResponse.builder()
                .users(users)
                .build();
    }

    @Override
    public void deleteUser(long userId) { this.realUserRepository.deleteById(userId); }

    @Override
    public ReadUserCountResponse getUserCount() {
        return ReadUserCountResponse.builder()
                .userCount(realUserRepository.getAllUsersCount())
                .build();
    }

    @Override
    public void updateAccountStatus(UpdateUserAccountStatus request) {
        Optional<UserEntity> userOptional = Optional.ofNullable(realUserRepository.findById(request.getId()));
        if (userOptional.isEmpty()) {
            throw new InvalidPostParametersException("Invalid parameters");
        }
        UserEntity user = userOptional.get();
        user.setIsUserActive(request.getNewStatus());
        realUserRepository.save(user);
    }
}