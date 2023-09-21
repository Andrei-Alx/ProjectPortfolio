package org.example.business.impl;

import lombok.RequiredArgsConstructor;
import org.example.business.AccessTokenEncoder;
import org.example.business.ILoginManager;
import org.example.business.exception.InvalidCredentialsException;
import org.example.business.exception.UnauthorizedAccessException;
import org.example.controller.domain.AccessToken;
import org.example.controller.domain.login.LoginRequest;
import org.example.controller.domain.login.LoginResponse;
import org.example.persistance.UserRepository;
import org.example.persistance.entity.UserEntity;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Objects;

@Service
@RequiredArgsConstructor
public class LoginManager implements ILoginManager {
    private final UserRepository userRepository;
    private final PasswordEncoder passwordEncoder;
    private final AccessTokenEncoder accessTokenEncoder;

    @Override
    public LoginResponse login(LoginRequest loginRequest) {
        UserEntity user = userRepository.findByEmail(loginRequest.getEmail());

        if(Objects.isNull(user) || !Objects.equals(user.getIsUserActive(), "Active")){
            throw new UnauthorizedAccessException("We could not find your account!");
        }
        else{
            if (!matchesPassword(loginRequest.getPassword(), user.getPassword())) {
                throw new InvalidCredentialsException();
            }
            String accessToken = generateAccessToken(user);
            return LoginResponse.builder().accessToken(accessToken).build();
        }
    }

    private boolean matchesPassword(String rawPassword, String encodedPassword) {
        return passwordEncoder.matches(rawPassword, encodedPassword);
    }

    private String generateAccessToken(UserEntity user) {
        Long userId;
        if (user != null){
            userId = user.getId();
        }
        else {
            userId = null;
        }
        int userRole = user.getUserRole();

        return accessTokenEncoder.encode(
                AccessToken.builder()
                        .subject(user.getEmail())
                        .role(userRole)
                        .userId(userId)
                        .build());
    }
}
